using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RAT
{
    class OrderInfoRepository
    {
        private ObservableCollection<OrderInfo> orderInfo;

        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }

        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            orderInfo.Add(new OrderInfo(1001, "X00110033", "123", "1234", "Berlin"));
            orderInfo.Add(new OrderInfo(1002, "X00334253", "1234", "ANATR", "Dublin"));
            orderInfo.Add(new OrderInfo(1003, "X00404240", "321", "ANTON", "Cork."));
        }
    }
}

