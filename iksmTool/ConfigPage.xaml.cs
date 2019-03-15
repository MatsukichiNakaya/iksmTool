using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Threading;
using Project.WPF.Controls;
using Project.Network;
using Project.Serialization.Json;
using Project.IO;

namespace iksmTool
{
    /// <summary>
    /// ConfigPage.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigPage : Page
    {

        public ConfigPage()
        {
            InitializeComponent();

            CircleProgressBar.SetValue(ref this.pathFore, 0, true);
            CircleProgressBar.SetValue(ref this.pathBack, 0, false);
        }


        private async void DownloadButton_Click(Object sender, RoutedEventArgs e)
        {
            this.DownloadButton.IsEnabled = false;
            Double counter = 0; //(7.2 / 3.6);
            Int32 count = 0;
            CircleProgressBar.SetValue(ref this.pathFore, counter, true);
            CircleProgressBar.SetValue(ref this.pathBack, counter, false);

#if false
            const String session = "";
            // 戦績リザルト 50試合
            String resultJson
                = Ikaring2API.GetJson(Ikaring2API.RESULT_URL, session);
            TextFile.Write(@"iksmResult.json", resultJson, TextFile.OVER_WRITE);
            var resultmodel = JsonSerializser.ConvertToClass<ResultModel>(resultJson);
#else
            var resultmodel = JsonSerializser.Load<ResultModel>(@"iksmResult.json");
#endif
            String filename;
            // 戦績詳細 バトルNo必要
            foreach (var item in resultmodel.results) {

                counter += (7.2 / 3.6);
                count++;
                filename = $@".\Battle\BattleResult_{item.battle_number}.json";
#if false
                if (!System.IO.File.Exists(filename)) {
                    String data = Ikaring2API.GetJson(String.Format(Ikaring2API.BATTLE_URL, item.battle_number), session);
                    TextFile.Write(filename, data, TextFile.OVER_WRITE);
                    await System.Threading.Tasks.Task.Delay(2000);
                }
#else
                await System.Threading.Tasks.Task.Delay(2000);
#endif
                CircleProgressBar.SetValue(ref this.pathFore, counter, true);
                CircleProgressBar.SetValue(ref this.pathBack, counter, false);
                this.valueBlock.Text = count.ToString();
            }
            this.DownloadButton.IsEnabled = true;
        }
    }

    /// <summary>
    /// 値を変換してバインディングするクラス
    /// </summary>
    public class DoubleToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format("{0}%", ((double)value).ToString("0.0"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double d;
            return double.TryParse(value.ToString(), out d) ? d : 0;
        }

    }
}
