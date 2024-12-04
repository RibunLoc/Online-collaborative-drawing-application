using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectTeam.Model
{
    public class DrawConnection
    {
        private string DiaChiServer;
        private int CongServer;
        private bool isConnected = false;
        TcpClient tcpClient;

        public DrawConnection(string DiaChiServer, int CongServer)
        {
            this.DiaChiServer = DiaChiServer;
            this.CongServer = CongServer;

        }

        /// <summary>
        /// Hàm dưới sẽ có nhiệm vụ gửi dữ liệu tới server những thông tin chức năng 
        /// vẽ như màu, cỡ, xóa.... (sau này sẽ thêm sau) 
        /// </summary>
        /// <param name="data">Dư liệu vẽ (chuỗi định dạng) </param>
        public void GuiDuLieuVe(string data)
        {
            try
            {
                using (TcpClient tcpclient = new TcpClient(DiaChiServer, CongServer))
                using (NetworkStream stream = tcpclient.GetStream())
                {
                    byte[] bodem = Encoding.ASCII.GetBytes(data);
                    stream.Write(bodem, 0 , bodem.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi dữ liệu: {ex.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public async Task GuiDuLieuAsync(string data)
        {
            if(!isConnected)
            {
                tcpClient = new TcpClient(DiaChiServer, CongServer);
                isConnected = true;
            }
            try
            {
                NetworkStream stream = tcpClient.GetStream();
        
                    if (stream.CanWrite)
                    {
                        byte[] bodem = Encoding.ASCII.GetBytes(data);
                        await stream.WriteAsync(bodem, 0, bodem.Length);
                        //await stream.FlushAsync();
                    }
                    else
                    {
                        MessageBox.Show("Không thể ghi vào Async");
                    }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi dữ liệu: {ex.Message}");
            }

        }

        /// <summary>
        /// Gửi tín hiệu bắt đầu vẽ
        /// </summary>
        public void GuiTinHieuBatDau()
        {
            GuiDuLieuVe("START");
        }
        
        /// <summary>
        /// Gửi tín hiệu xóa toàn bộ  
        /// </summary>
        public void GuiTinHieuXoaHet()
        {
            GuiDuLieuVe("CLEAR");
        }


    }
}
