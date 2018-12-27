using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using CN.Pedant.SweetAlert;
using static CN.Pedant.SweetAlert.SweetAlertDialog;

namespace Xam.SweetAlert.Droid.Test
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public class MyClick :Java.Lang.Object, IOnSweetClickListener
        {
            public void OnClick(SweetAlertDialog sweetAlertDialog)
            {
                sweetAlertDialog.SetTitleText("已刪除")
                        .SetContentText("你的資料已經刪除")
                        .ShowCancelButton(false)
                        .SetConfirmText("完成")
                        .SetConfirmClickListener(null)
                        .ChangeAlertType(SweetAlertDialog.SuccessType);
            }
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            this.FindViewById<Button>(Resource.Id.button1).Click += (sender, e) =>
            {
                new SweetAlertDialog(this, SweetAlertDialog.WarningType)
                             .SetTitleText("確認視窗")
                             .SetContentText("是否要刪除檔案?")
                             .SetConfirmText("刪除")
                             .SetCancelText("取消")
                             .SetConfirmClickListener(new MyClick())
                            .Show();
            };
  
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

