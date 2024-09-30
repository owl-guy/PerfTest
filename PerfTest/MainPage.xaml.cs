namespace PerfTest
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var animation = new Animation(v =>
            {
                int r = new Random().Next();
                CounterBtn.Text = (r).ToString();

            }, 0, 0);
            animation.Commit(this, "animation", 16, 250, null, null, () => true);

            //This also creates new TweenerAnimation objects continuously, only at a slower pace because of the length
            //var animation = new Animation(v =>
            //{
            //    CounterBtn.Opacity = v;
            //}, 1, 0, Easing.Linear);
            //animation.Commit(this, "animation", length: 2000, repeat: () => true);
        }
    }

}
