﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelClient.Service
{
    public interface IDialogService
    {
        bool? ShowDialog(object dialogViewModel); 
    }
}
