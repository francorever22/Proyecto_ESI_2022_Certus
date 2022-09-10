using Microsoft.Toolkit.Uwp.Notifications;

namespace Sistema_de_Resultados_Deportivos
{
    internal class Toast
    {
        private static Toast baker = null;
        public Toast(int x, String title, String msg)
        {
            baker = this;
            SelectBread(x, title, msg);
        }

        private void MatchBeginsToast(String title, String msg)
        {
            new ToastContentBuilder()
            .AddText(title)
            .AddText(msg)
            .AddInlineImage(NewImage(new Bitmap(Properties.Resources.barcelona), new Bitmap(Properties.Resources.realmadrid), 1, null))
            .Show();
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                ToastClick(1);
            };
        }

        private void MatchScoreToast(String title, String msg)
        {
            new ToastContentBuilder()
            .AddText(title)
            .AddText(msg)
            .AddInlineImage(NewImage(new Bitmap(Properties.Resources.barcelona), new Bitmap(Properties.Resources.realmadrid), 2, "10 - 10"))
            .Show();
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                ToastClick(1);
            };
        }

        private void MatchRoundToast(String title, String msg)
        {
            new ToastContentBuilder()
            .AddText(title)
            .AddText(msg)
            .AddInlineImage(NewImage(new Bitmap(Properties.Resources.barcelona), new Bitmap(Properties.Resources.realmadrid), 2, "1 - 1"))
            .Show();
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                ToastClick(1);
            };
        }

        private void MatchNotificationToast(String title, String msg)
        {
            new ToastContentBuilder()
            .AddText(title)
            .AddText(msg)
            .Show();
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                ToastClick(1);
            };
        }

        private void EventToast(String title, String msg)
        {
            new ToastContentBuilder()
            .AddText(title)
            .AddText(msg)
            .AddInlineImage(NewImage(new Bitmap(Properties.Resources.barcelona), null, 4, null))
            .Show();
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                ToastClick(2);
            };
        }

        private void ToastClick(int type)
        {
            Principal.AlterPrincipal(type, 4, 1);
        }

        private void SelectBread(int x, String title, String msg)
        {
            switch (x)
            {
                case 0:
                    baker.MatchBeginsToast(title, msg);
                    break;
                case 1:
                    baker.MatchScoreToast(title, msg);
                    break;
                case 2:
                    baker.MatchRoundToast(title, msg);
                    break;
                case 3:
                    baker.MatchNotificationToast(title, msg);
                    break;
                case 4:
                    baker.EventToast(title, msg);
                    break;
            }
        }

        private Uri NewImage(Bitmap image1, Bitmap image2, int type, String textImage)
        {
            /* Types 
             * 1) Match beginnig
             * 2) Match score */
            Bitmap first;
            Bitmap second;
            switch (type)
            {
                case 1: //For VS
                    Bitmap vs = new Bitmap(Properties.Resources.versus);

                    first = new Bitmap(image1.Width + vs.Width, 180);
                    using (Graphics g = Graphics.FromImage(first))
                    {
                        g.DrawImage(image1, 0, 15);
                        g.DrawImage(vs, image1.Width, 0);
                    }

                    second = new Bitmap(first.Width + image2.Width, 180);
                    using (Graphics g = Graphics.FromImage(second))
                    {
                        g.DrawImage(first, 0, 0);
                        g.DrawImage(image2, first.Width, 15);
                    }

                    second.Save("toast.png");
                    break;
                case 2: //For score
                    Bitmap score = new Bitmap(GetText(textImage, 1));

                    first = new Bitmap(image1.Width + score.Width, 180);
                    using (Graphics g = Graphics.FromImage(first))
                    {
                        g.DrawImage(image1, 0, 15);
                        g.DrawImage(score, image1.Width, 90 - score.Height/2);
                    }

                    second = new Bitmap(first.Width + image2.Width, 180);
                    using (Graphics g = Graphics.FromImage(second))
                    {
                        g.DrawImage(first, 0, 0);
                        g.DrawImage(image2, first.Width, 15);
                    }

                    second.Save("toast.png");
                    break;
                case 3: //For round

                    Bitmap r = new Bitmap(GetText("Round", 2));
                    Bitmap nRound = new Bitmap(GetText(textImage, 2));
                    Bitmap round = new Bitmap(r.Width, r.Height + nRound.Height);
                    using (Graphics g = Graphics.FromImage(round))
                    {
                        g.DrawImage(r, 0, 0);
                        g.DrawImage(nRound, -5, r.Height);
                    }

                    first = new Bitmap(image1.Width + round.Width, 180);
                    using (Graphics g = Graphics.FromImage(first))
                    {
                        g.DrawImage(image1, 0, 15);
                        g.DrawImage(round, image1.Width, 90 - round.Height / 2);
                    }

                    second = new Bitmap(first.Width + image2.Width, 180);
                    using (Graphics g = Graphics.FromImage(second))
                    {
                        g.DrawImage(first, 0, 0);
                        g.DrawImage(image2, first.Width, 15);
                    }

                    second.Save("toast.png");
                    break;
                case 4: //For single images

                    first = new Bitmap(364, 180);
                    using (Graphics g = Graphics.FromImage(first))
                    {
                        g.DrawImage(image1, 107, 15);
                    }

                    first.Save("toast.png");
                    break;
            }
            Uri uri = new Uri(@"C:\Users\Hinoken\source\repos\Proyecto_ESI_2022_Certus\Sistema de Resultados Deportivos\bin\Debug\net6.0-windows10.0.17763.0\toast.png");
            return uri;
        }

        private Bitmap GetText(String text, int size)
        {
            Bitmap s = null;
            Font drawFont = null;
            SolidBrush drawBrush = new SolidBrush(Color.White);
            StringFormat drawFormat = new StringFormat();
            switch (size)
            {
                case 1:
                    drawFont = new Font("Segoe UI", 30);

                    s = new Bitmap(text.Length * 20, 80);

                    using (Graphics g = Graphics.FromImage(s))
                    {
                        g.DrawString(text, drawFont, drawBrush, 0, 0, drawFormat);
                    }
                    break;
                case 2:
                    drawFont = new Font("Segoe UI", 20);

                    s = new Bitmap(180, 40);
                    float x = (180 - text.Length * 20) / 2;

                    using (Graphics g = Graphics.FromImage(s))
                    {
                        g.DrawString(text, drawFont, drawBrush, x, 0, drawFormat);
                    }
                    break;
            }
            return s;
        }
    }
}
