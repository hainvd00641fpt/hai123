using ASM.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUp1 : Page
    {
        private StorageFile photo;
        private string currentUploadUrl;
        Member _currentMember;
        public SignUp1()
        {
            _currentMember = new Member();
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }


        //chup anh
        private async void Choose_Image(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);
            photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

                if(photo == null)
            {
                return;
            }
            HttpClient httpClient = new HttpClient();
            currentUploadUrl = await httpClient.GetStringAsync(Entity.ServiceUrl.GET_UPLOAD_URL);
            Debug.WriteLine("Upload url:" + currentUploadUrl);
            await HttpUploadFileAsync(currentUploadUrl, "myFile", "image/png");

        }
        //up load anh
        ///<param name = "url" ></ param >
        /// <param name="paramName"></param>
        /// <param name="contentType"></param>
        private async System.Threading.Tasks.Task HttpUploadFileAsync(string url, string paramName, string contentType)
        {
            string boundary = "............" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary" + boundary;
            wr.Method = "POST";

            Stream rs = await wr.GetRequestStreamAsync();
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, "path_file", contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            // write file.
            Stream fileStream = await this.photo.OpenStreamForReadAsync();
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);

            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                string imageUrl = reader2.ReadToEnd();
                avatar.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                AvatarURL.Text = imageUrl;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error uploading file", ex.StackTrace);
                Debug.WriteLine("Error uploading file", ex.InnerException);
                if (wresp != null)
                {
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }
        //ngay thang
        private void Do_Datebirthday(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            this._currentMember.birthday = Birthday.Date.Value.ToString("yyyy-MM-dd");
        }
        // gioi tinh
        private void Do_checked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            this._currentMember.gender = Int32.Parse(radio.Tag.ToString());
        }

        private void doSubmit_Click(object sender, RoutedEventArgs e)
        {
            this._currentMember.firstName = this.FirstName.Text;
            this._currentMember.lastName = this.LastName.Text;
            this._currentMember.email = this.Email.Text;
            this._currentMember.password = this.Password.Password;
            this._currentMember.phone = this.Phone.Text;
            this._currentMember.avatar = this.AvatarURL.Text;
            this._currentMember.address = this.Address.Text;
            this._currentMember.introduction = this.Introduction.Text;


            // ép kiểu từ string sang Json
            string JsonMember = JsonConvert.SerializeObject(this._currentMember);
            Debug.WriteLine(JsonMember);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(JsonMember, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(Entity.ServiceUrl.API_REGISTER, content);
            this.FirstName.Text = string.Empty;
            this.LastName.Text = string.Empty;
            this.Email.Text = string.Empty;
            this.Password.Password = string.Empty;
            this.AvatarURL.Text = string.Empty;
            this.Phone.Text = string.Empty;
            this.Address.Text = string.Empty;
            this.Introduction.Text = string.Empty;
            //validata
            if (response.Result.StatusCode == HttpStatusCode.Created)
            {
                // success
            }
            else
            {
                ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(contents);
                if (errorResponse.error.Count > 0)
                {
                    foreach (var key in errorResponse.error.Keys)
                    {
                        var objectByKey = this.FindName(key);
                        var value = errorResponse.error[key];
                        if (objectByKey != null)
                        {
                            TextBlock textBlock = objectByKey as TextBlock;
                            textBlock.Text = "* " + value;
                            textBlock.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
            return "";
        }
    }

        private void doReset_Click(object sender, RoutedEventArgs e)
        {

        }
    }



    }

