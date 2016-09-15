using System;
using System.IO;
using System.Threading;

namespace LabManager.Util
{

    class Log
    {
        /// <summary>
        /// 对象锁，用于异步写入日志时防止多个线程同时写入造成写入失败
        /// </summary>
        private static readonly Object LockObj = new object();
        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input">string，待写入的日志内容</param>
        public static void WriteLogFile(string input)
        {
            ///指定日志文件的目录
            string fname = Directory.GetCurrentDirectory() + "\\LogFile.txt";
            ///定义文件信息对象
            FileInfo finfo = new FileInfo(fname);
            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(fname);
                fs.Close();
                finfo = new FileInfo(fname);
            }
            ///判断文件是否存在以及是否大于2K
            if (finfo.Length > 1024 * 1024 * 10)
            {
                ///文件超过10MB则重命名
                File.Move(Directory.GetCurrentDirectory() + "\\LogFile.txt", Directory.GetCurrentDirectory() + DateTime.Now.TimeOfDay + "\\LogFile.txt");
                ///删除该文件
                //finfo.Delete();
            }
            Thread thread = new Thread(() =>
            {
                lock (LockObj)
                {
                    //finfo.AppendText();
                    ///创建只写文件流
                    using (FileStream fs = finfo.OpenWrite())
                    {
                        ///根据上面创建的文件流创建写数据流
                        StreamWriter w = new StreamWriter(fs);
                        ///设置写数据流的起始位置为文件流的末尾
                        w.BaseStream.Seek(0, SeekOrigin.End);
                        ///写入“Log Entry : ”
                        //w.Write("\r\nLog Entry : ");
                        ///写入当前系统时间并换行
                        w.Write("{0} {1} \r\n", DateTime.Now.ToLongDateString(),
                            DateTime.Now.ToLongTimeString());
                        ///写入日志内容并换行
                        w.Write(input + "\r\n");
                        ///写入------------------------------------“并换行
                        w.Write("------------------------------------\r\n\r\n");
                        ///清空缓冲区内容，并把缓冲区内容写入基础流
                        w.Flush();
                        ///关闭写数据流
                        w.Close();
                    }
                }
            });
            thread.Start();
        }
    }
}
