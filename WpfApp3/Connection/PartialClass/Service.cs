using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp3.Connection
{
    public partial class Service
    {
        public string CostStr
        {
            get
            {
                if (Discount == null)
                {
                    return $"{Cost} рублей за {DurationInSeconds / 60} минут";
                }
                else
                {
                    return $"{Cost} {(double)Cost * (1 - Discount)} рублей за {DurationInSeconds / 60} минут";
                }
            }
        }
        public string DiscountStr
        {
            get
            {
                if (Discount != null)
                {
                    return $"*{Discount * 100}%";

                }
                return null;
            }
        }

        public Visibility CostVisibl
        {
            get
            {
                if (Discount == null)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public BitmapImage GetImage
        {
            get
            {
                if (MainImagePath != null)
                {
                    return new BitmapImage(new Uri($"\\Resoers\\{MainImagePath}", UriKind.Relative));
                }
                else
                {
                    return new BitmapImage(new Uri(@"\Resoers\\school_logo.png",UriKind.Relative));
                }
            } 
        }

    }
}
