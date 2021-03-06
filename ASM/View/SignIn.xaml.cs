﻿using ASM.Entity;
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
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignIn : Page
    {
        Member currentMemberLogin;
        Token currentToken;
        public SignIn()
        {
            currentToken = new Token();
            currentMemberLogin = new Member();
            this.InitializeComponent();
        }

        private async void Do_login(object sender, RoutedEventArgs e)
        {
            this.currentMemberLogin.email = this.Email1.Text;
            this.currentMemberLogin.password = this.lPassword.Password;

            string jsonMember = JsonConvert.SerializeObject(this.currentMemberLogin);
            Debug.WriteLine(jsonMember);

            HttpClient httpClient = new HttpClient();
            var content = new StringContent(jsonMember, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(Entity.ServiceUrl.API_LOGIN, content);
            var contents = await response.Result.Content.ReadAsStringAsync();
            Debug.WriteLine(contents);

            currentToken = JsonConvert.DeserializeObject<Token>(contents);
            Debug.WriteLine(currentToken.token);
            this.Email1.Text = string.Empty;
            this.lPassword.Password = string.Empty;

            if (response.Result.StatusCode == HttpStatusCode.Created)
            {
                await CreatedFileToken();
                this.Frame.Navigate(typeof(View.Information));

            }
            else
            {
                ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(contents);

                this.ValidateError.Text = errorResponse.message;

            }
        }

        private async Task CreatedFileToken()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("Token.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            sampleFile = await storageFolder.GetFileAsync("Token.txt");
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, currentToken.token);

        }

        private void Go_Rigister(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(View.SignUp1));
        }
    }
}
