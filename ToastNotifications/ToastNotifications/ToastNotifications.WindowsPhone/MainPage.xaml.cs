using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Toast Gönderi İçin Gerekli Kütüphaneler
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToastNotifications
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;

        private void bttn_Toast(object sender, RoutedEventArgs e)
        {
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            var toastText = toastXml.GetElementsByTagName("text");
            (toastText[0] as XmlElement).InnerText = "Line 1";
            var toast = new ToastNotification(toastXml);
            toastNotifier.Show(toast);

        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");          //Text Notification    

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast"); //Create toast node so you can add separete audio and duration    

            ((XmlElement)toastNode).SetAttribute("duration", "long");     //Toast Duration short or long [optional]    

            ToastNotification toast = new ToastNotification(toastXml);                      //create object of toast notificaion     

            toast.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(3600);                  //Auto remove Notificaiton [Optional]    

            ToastNotificationManager.CreateToastNotifier().Show(toast);                     //Show toast notification.    
        }
        
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");          //Text Notification    
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Zikri Tamamladınız"));       //Heading text of Notification    

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast"); //Create toast node so you can add separete audio and duration    

            ((XmlElement)toastNode).SetAttribute("duration", "long");   //Toast Duration short or long [optional]    

            ToastNotification toast = new ToastNotification(toastXml);                      //create object of toast notificaion     

            toast.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(3600);                  //Auto remove Notificaiton [Optional]    

            ToastNotificationManager.CreateToastNotifier().Show(toast);                     //Show toast notification.    
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");          //Text Notification    

            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Zikirmatik Ekstra"));       //Heading text of Notification    

            toastTextElements[1].AppendChild(toastXml.CreateTextNode("Zikriniz Tamamlandı"));    //Body text of Notification    

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");  //Create toast node so you can add separete audio and duration    

            ((XmlElement)toastNode).SetAttribute("duration", "long");        //Toast Duration short or long [optional]    

            ToastNotification toast = new ToastNotification(toastXml);   //create object of toast notificaion     

            toast.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(3600);        //Auto remove Notificaiton [Optional]    

            ToastNotificationManager.CreateToastNotifier().Show(toast);                 //Show toast notification.    
        }

        private void b4_Click(object sender, RoutedEventArgs e) //Navigation code for second page navigation   
        {
            this.Frame.Navigate(typeof(BlankPage1));
        }

    }
}
