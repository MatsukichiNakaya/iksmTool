using System;
using System.Windows;
using System.Windows.Media;

namespace Project.WPF.Controls
{
    public class CircleProgressBar
    {
        private const Double RAD = 0.0174532925199;
        private const Double ROUND_ANGLE = 360;
        private const Double RIGHT_ANGLE = 90;
        private const Double STRAIGHT_ANGLE = 180;
        private const Double END_OFFSET = 0.1;

        /// <summary>
        /// プログレスバーに値を設定
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value">設定値</param>
        /// <param name="isFront">前景(true)/背景(false)</param>
        public static void SetValue(ref System.Windows.Shapes.Path element,
                                    Double value, Boolean isFront)
        {
            Double thick = element.StrokeThickness / 2.0;
            Double inputValue = Math.Floor(value);
            // 100% ～ 0% の値を360°の何度にあたるか計算
            Double angle = CalcAngle(inputValue);

            // 始点 設定
            var fig = new PathFigure()
            {
                StartPoint = new Point((element.Width / 2.0), thick)
            };

            // 角度と半径から座標を計算
            Double radius = (element.Width / 2.0) - thick;  // 半径
            var endPoint = CalcEndPint(angle, radius);       // 描画の終点作成

            // 180°を超える(180を含む)場合はフラグをtrue
            Boolean isLargeArcFlg = angle >= STRAIGHT_ANGLE;

            // セグメント生成
            var seg = new ArcSegment()
            {   // 終点は線の太さの修正を入れる
                Point = new Point(endPoint.X + thick, endPoint.Y + thick),
                Size = new Size(radius, radius),
                IsLargeArc = isFront ? isLargeArcFlg : !isLargeArcFlg,
                SweepDirection = isFront ? SweepDirection.Clockwise
                                         : SweepDirection.Counterclockwise,
                RotationAngle = 0
            };

            // Data Set
            fig.Segments.Clear();
            fig.Segments.Add(seg);
            element.Data = new PathGeometry(new PathFigure[] { fig });
        }

        /// <summary></summary>
        private static Double CalcAngle(Double inputValue)
        {
            Double result = (inputValue * 3.6); // 3.6 = ROUND_ANGLE / 100
            if (result <= 0) { return END_OFFSET; }
            if(result >= ROUND_ANGLE) { return ROUND_ANGLE - END_OFFSET; }
            return result;
        }

        /// <summary>
        /// 終点の座標を計算
        /// </summary>
        /// <param name="angle">角度</param>
        /// <param name="radius">半径</param>
        /// <returns></returns>
        private static Point CalcEndPint(Double angle, Double radius)
        {
            Double actualAngle = angle - RIGHT_ANGLE;
            Double radian = Math.PI * actualAngle / STRAIGHT_ANGLE;
            Double x = radius * Math.Cos(radian);
            Double y = radius * Math.Sin(radian);
            return new Point(radius + x, radius + y);
        }
    }
}
