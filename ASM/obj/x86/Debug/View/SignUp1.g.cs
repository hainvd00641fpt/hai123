﻿#pragma checksum "C:\Users\Admin\source\repos\ASM\ASM\View\SignUp1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AD0B147F740923BCD2972B30FF9292ED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASM.View
{
    partial class SignUp1 : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\SignUp1.xaml line 19
                {
                    this.avatar = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3: // View\SignUp1.xaml line 35
                {
                    this.Email = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // View\SignUp1.xaml line 36
                {
                    this.email = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // View\SignUp1.xaml line 37
                {
                    this.Password = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 6: // View\SignUp1.xaml line 38
                {
                    this.password = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // View\SignUp1.xaml line 39
                {
                    this.Phone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // View\SignUp1.xaml line 40
                {
                    this.phone = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // View\SignUp1.xaml line 81
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.doSubmit_Click;
                }
                break;
            case 10: // View\SignUp1.xaml line 82
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.doReset_Click;
                }
                break;
            case 11: // View\SignUp1.xaml line 70
                {
                    this.Address = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12: // View\SignUp1.xaml line 71
                {
                    this.address = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // View\SignUp1.xaml line 72
                {
                    this.Introduction = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14: // View\SignUp1.xaml line 58
                {
                    this.Birthday = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.CalendarDatePicker)this.Birthday).DateChanged += this.Do_Datebirthday;
                }
                break;
            case 15: // View\SignUp1.xaml line 59
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element15 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element15).Checked += this.Do_checked;
                }
                break;
            case 16: // View\SignUp1.xaml line 60
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element16 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element16).Checked += this.Do_checked;
                }
                break;
            case 17: // View\SignUp1.xaml line 61
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element17 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element17).Checked += this.Do_checked;
                }
                break;
            case 18: // View\SignUp1.xaml line 46
                {
                    this.AvatarURL = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 19: // View\SignUp1.xaml line 47
                {
                    global::Windows.UI.Xaml.Controls.Button element19 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element19).Click += this.Choose_Image;
                }
                break;
            case 20: // View\SignUp1.xaml line 29
                {
                    this.FirstName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 21: // View\SignUp1.xaml line 30
                {
                    this.LastName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 22: // View\SignUp1.xaml line 31
                {
                    this.firstname = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 23: // View\SignUp1.xaml line 32
                {
                    this.lastname = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

