using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTDBRetrieval
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "iyMfDOLiSUAV6CTQE6JWSgpFOawTOjnfffHtaDsI",
            BasePath = "https://testfire-41161-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        static IFirebaseClient firebaseClient;
        public MainWindow()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient(config);
            RTDBUpdate();
        }
        static int datas;
        async void RTDBUpdate()
        {
            while (true)
            {
                await Task.Delay(1000);
                try
                {
                    FirebaseResponse response = firebaseClient.Get("Test");
                    var data = new Data
                    {
                        TestValue = 0
                    };
                    Data obj = response.ResultAs<Data>();
                    datas = obj.TestValue;
                    RTDB.Text = (obj.TestValue.ToString());
                }
                catch (Exception ex) { }
            }

        }

        internal class Data
        {
            public int TestValue { get; internal set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Data is" + datas.ToString());
        }
    }
}

