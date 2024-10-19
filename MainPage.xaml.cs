using Microsoft.Maui.Controls.Shapes;

namespace clock
{
    public partial class MainPage : ContentPage
    {
        Dictionary<int, long> numbersMasks = new Dictionary<int, long>
        {
            { 0, 0b01110_10001_10001_10001_10001_10001_01110 },
            { 1, 0b00100_01100_10100_00100_00100_00100_11111 },
            { 2, 0b01110_10001_00001_00010_00100_01000_11111 },
            { 3, 0b01110_10001_00001_00010_00001_10001_01110 }, 
            { 4, 0b10001_10001_10001_11111_00001_00001_00001 },
            { 5, 0b11111_10000_10000_01110_00001_00001_11110 },
            { 6, 0b01110_10001_10000_11110_10001_10001_01110 },
            { 7, 0b11111_00001_00001_00010_00100_01000_10000 },
            { 8, 0b01110_10001_10001_01110_10001_10001_01110 },
            { 9, 0b01110_10001_10001_01111_00001_10001_01110 }
        };

        Dictionary<Grids, Grid> numbersGrids;

        public enum Grids { Hours_1 = 1, Hours_2, Minutes_1, Minutes_2, Seconds_1, Seconds_2 };

        TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);

        private PeriodicTimer _timer;
        private CancellationTokenSource _cancellationTokenSource;

        public MainPage()
        {
            InitializeComponent();

            numbersGrids = new Dictionary<Grids, Grid>
            {
                { Grids.Hours_1, HoursDisplay_1 },
                { Grids.Hours_2, HoursDisplay_2 },
                { Grids.Minutes_1, MinutesDisplay_1 },
                { Grids.Minutes_2, MinutesDisplay_2 },
                { Grids.Seconds_1, SecondsDisplay_1 },
                { Grids.Seconds_2, SecondsDisplay_2 }
            };

            StartTimer();
        }

        private async void StartTimer()
        {
            _timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                while (await _timer.WaitForNextTickAsync(_cancellationTokenSource.Token))
                {
                    updateTime();
                }
            } catch (OperationCanceledException)
            {
                Console.WriteLine("Timer canceled.");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            StopTimer();
        }

        private void StopTimer()
        {
            _cancellationTokenSource?.Cancel();
            _timer?.Dispose();
        }

        public void updateTime()
        {
            time = TimeOnly.FromDateTime(DateTime.Now);
            WriteTime();
        }

        public void WriteTime()
        {
            WriteNumber(time.Hour / 10, Grids.Hours_1);
            WriteNumber(time.Hour % 10, Grids.Hours_2);
            WriteNumber(time.Minute / 10, Grids.Minutes_1);
            WriteNumber(time.Minute % 10, Grids.Minutes_2);
            WriteNumber(time.Second / 10, Grids.Seconds_1);
            WriteNumber(time.Second % 10, Grids.Seconds_2);
        }

        public void WriteNumber(int number, Grids gridId)
        {
            Grid grid = numbersGrids[gridId];
            grid.Clear();

            long mask = numbersMasks[number];
            int i = 0;
            for (int row = 0; row < grid.RowDefinitions.Count; row++)
            {
                for (int col = 0; col < grid.ColumnDefinitions.Count; col++)
                {
                    int bitValue = (int)((mask >> 34 - i++) & 1);
                    
                    if (bitValue == 1)
                    {
                        grid.Add(CreateTile(), col, row);
                    }
                }
            }
        }

        public Rectangle CreateTile()
        {
            return new Rectangle
                {
                    BackgroundColor = new Color(255, 255, 255),
                    HeightRequest = 20,
                    WidthRequest = 20,
                };
        }
    }
}
