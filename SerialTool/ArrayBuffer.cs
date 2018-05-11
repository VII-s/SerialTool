using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;

namespace SerialTool
{
    /// <summary>
    /// 使用字节数组来实现的缓冲区. 该缓冲区把该数组看作是一个环,
    /// 将写入的数据环形存入缓冲区，如果空间不足则覆盖旧的数据
    /// </summary>
    /// <typeparam name="T">所缓冲的数据类型.</typeparam>
    class ArrayBuffer<T>
    {
        /// <summary>
        /// 默认大小.
        /// </summary>
        private const int DFLT_SIZE = 512 * 1024;
        /// <summary>
        /// 缓冲区中的数据元素数目.
        /// </summary>
        private int available = 0;
        /// <summary>
        /// 缓冲区的容量.
        /// </summary>
        private int capacity = DFLT_SIZE;
        // 注意 capacity 和 buf.Length 可以不相同, 前者小于或者等于后者.
        /// <summary>
        /// 下一次要将数据写入缓冲区的开始下标.
        /// </summary>
        private int wr_nxt = 0;
        /// <summary>
        /// 缓冲区所使用的数组.
        /// </summary>
        private T[] dataBuf;
        private object bufLock = new object();

        public ArrayBuffer()
            : this(DFLT_SIZE)
        {
        }
        /// <summary>
        /// 创建一个指定容量的缓冲区.
        /// </summary>
        /// <param name="capacity">缓冲区的容量.</param>
        public ArrayBuffer(int capacity)
            : this(new T[capacity])
        {
        }
        /// <summary>
        /// 使用指定的数组来创建一个缓冲区.
        /// </summary>
        /// <param name="buf">缓冲区将要使用的数组.</param>
        public ArrayBuffer(T[] buf)
            : this(buf, 0, 0)
        {
        }
        /// <summary>
        /// 使用指定的数组来创建一个缓冲区, 且该数组已经包含数据.
        /// </summary>
        /// <param name="buf">缓冲区将要使用的数组.</param>
        /// <param name="offset">数据在数组中的偏移.</param>
        /// <param name="size">数据的字节数.</param>
        public ArrayBuffer(T[] buf, int offset, int size)
        {
            this.dataBuf = buf;
            capacity = buf.Length;
            available = size;
            wr_nxt = offset + size;
        }

        /// <summary>
        /// 缓冲区中可供读取的数据的元素数目
        /// </summary>
        public int Available
        {
            get
            {
                return available;
            }
        }

        /// <summary>
        /// get, set 接收缓冲区的大小(元素数目). 默认值为 512K.
        /// Capacity 不能设置为小于 Available 的值(实现会忽略这样的值).
        /// </summary>
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                lock (bufLock)
                {
                    if ( value == 0)
                    {
                        return;
                        //throw new ApplicationException("Capacity must be larger than Available.");
                    }
                    if (value == capacity)
                    {
                        return;
                    }
                    T[] buf = new T[value];
                    if (available > 0)
                    {
                        available = ReadData(buf, 0, buf.Length);
                        // 下面的用法是错误的!
                        //available = Read(buf, 0, buf.Length);
                    }
                    dataBuf = buf;
                    capacity = value;
                    // 当容量缩小时, 可能导致变化后可写空间为0, 这时wr_nxt=0.
                    wr_nxt = ((capacity - available )== 0) ? 0 : available;
                }
            }
        }

        /// <summary>
        /// 把本缓冲区的数据复制指定的数组中, 并移动读指针.
        /// </summary>
        private int ReadData(T[] buf, int offset, int size)
        {
            int nread = (available >= size) ? size : available;
            if(wr_nxt < nread)
            {
                // 两次拷贝.
                Array.Copy(dataBuf, (capacity - (nread - wr_nxt)), buf, offset, (nread - wr_nxt));
                Array.Copy(dataBuf, 0, buf, offset + (nread - wr_nxt), wr_nxt);
            }
            else
            {
                Array.Copy(dataBuf, (wr_nxt - nread), buf, offset, nread);
            }
            return nread;
        }

        /// <summary>
        /// 清空本缓冲区.
        /// </summary>
        public void Clear()
        {
            lock (bufLock)
            {
                available = 0;
                wr_nxt = 0;
            }
        }

        /// <summary>
        /// 从缓冲区中读取数据. 读取的字节数一定是 buf.Length 和 Available 的较小者.
        /// </summary>
        /// <param name="buf">存储接收到的数据的缓冲区.</param>
        /// <returns>已经读取的字节数. 一定是 size 和 Available 的较小者.</returns>
        public int Read(T[] buf)
        {
            return Read(buf, 0, buf.Length);
        }

        /// <summary>
        /// 从缓冲区中读取数据. 读取的字节数一定是 size 和 Available 的较小者.
        /// 本方法是线程安全的.
        /// </summary>
        /// <param name="buf">存储接收到的数据的缓冲区.</param>
        /// <param name="offset">buf 中存储所接收数据的位置.</param>
        /// <param name="size">要读取的字节数.</param>
        /// <returns>已经读取的字节数. 一定是 size 和 Available 的较小者.</returns>
        public int Read(T[] buf, int offset, int size)
        {
            lock (bufLock)
            {
                int nread = ReadData(buf, offset, size);
                return nread;
            }
        }

        /// <summary>
        /// 写入数据到缓冲区.
        /// </summary>
        /// <param name="buf">要写入的数据的缓冲区.</param>
        public void Write(T[] buf)
        {
            Write(buf, 0, buf.Length);
        }
        /// <summary>
        /// 写入数据到缓冲区. 注意: 本方法不是线程安全的.
        /// </summary>
        /// <param name="buf">要写入的数据的缓冲区.</param>
        /// <param name="offset">数据缓冲区中要写入数据的起始位置.</param>
        /// <param name="size">要写入的字节数.</param>
        /// <exception cref="ApplicationException">如果空间不足, 会抛出异常.</exception>
        public void Write(T[] buf, int offset, int size)
        {
            lock (bufLock)
            {
                if (size <= capacity - wr_nxt)
                {
                    Array.Copy(buf, offset, dataBuf, wr_nxt, size);
                    wr_nxt += size;
                }
                else if (size <= capacity)
                {
                    Array.Copy(buf, offset, dataBuf, wr_nxt, capacity - wr_nxt);
                    Array.Copy(buf, offset + (capacity - wr_nxt), dataBuf, 0, size - (capacity - wr_nxt));
                    wr_nxt = size - (capacity - wr_nxt);
                }
                else
                {
                    Array.Copy(buf, offset + (size - capacity), dataBuf, 0, capacity);
                    wr_nxt = 0;
                }
                available += size;
                available = (available > capacity) ? capacity : available;
            } 
        }
    }
}
