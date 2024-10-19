using Microsoft.Maui.Controls.Shapes;

namespace clock
{
    public partial class MainPage : ContentPage
    {
        TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);

        [Obsolete]
        public MainPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() => updateTime());
                return true;
            });

            WriteTime();
        }

        public void updateTime()
        {
            time = TimeOnly.FromDateTime(DateTime.Now);
            Display.Clear();
            WriteTime();
        }

        public void WriteTime()
        {
            WriteNumber(time.Hour / 10);
            WriteNumber(time.Hour % 10);
            WriteColon();
            WriteNumber(time.Minute / 10);
            WriteNumber(time.Minute % 10);
            WriteColon();
            WriteNumber(time.Second / 10);
            WriteNumber(time.Second % 10);
        }

        public void WriteNumber(int number)
        {
            Grid grid = new Grid
            {
                HeightRequest = 140,
                WidthRequest = 100,
                RowSpacing = 5,
                ColumnSpacing = 5,
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition()
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition()
                }
            };

            switch(number)
            {
                case 0:
                    WriteZero(grid);
                    break;
                case 1:
                    WriteOne(grid);
                    break;
                case 2:
                    WriteTwo(grid);
                    break;
                case 3:
                    WriteThree(grid);
                    break;
                case 4:
                    WriteFour(grid);
                    break;
                case 5:
                    WriteFive(grid);
                    break;
                case 6:
                    WriteSix(grid);
                    break;
                case 7:
                    WriteSeven(grid);
                    break;
                case 8:
                    WriteEight(grid);
                    break;
                case 9:
                    WriteNine(grid);
                    break;
            }

            Display.Add(grid);
        }

        public void WriteColon()        {
            Grid grid = new Grid
            {
                HeightRequest = 140,
                WidthRequest = 100,
                RowSpacing = 5,
                ColumnSpacing = 5,
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition()
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition()
                }
            };

            grid.Add(CreateTile(), 1, 3);
            grid.Add(CreateTile(), 1, 5);

            Display.Add(grid);
        }

        public void WriteZero(Grid grid)
        {
            grid.Add(CreateTile(), 2, 1);
            grid.Add(CreateTile(), 3, 1);
            grid.Add(CreateTile(), 4, 1);
            grid.Add(CreateTile(), 1, 2);
            grid.Add(CreateTile(), 5, 2);
            grid.Add(CreateTile(), 1, 3);
            grid.Add(CreateTile(), 5, 3);
            grid.Add(CreateTile(), 1, 4);
            grid.Add(CreateTile(), 5, 4);
            grid.Add(CreateTile(), 1, 5);
            grid.Add(CreateTile(), 5, 5);
            grid.Add(CreateTile(), 1, 6);
            grid.Add(CreateTile(), 5, 6);
            grid.Add(CreateTile(), 2, 7);
            grid.Add(CreateTile(), 3, 7);
            grid.Add(CreateTile(), 4, 7);
        }

        public void WriteOne(Grid grid)
        {
            grid.Add(CreateTile(), 3, 1);
            grid.Add(CreateTile(), 2, 2);
            grid.Add(CreateTile(), 3, 2);
            grid.Add(CreateTile(), 1, 3);
            grid.Add(CreateTile(), 3, 3);
            grid.Add(CreateTile(), 3, 4);
            grid.Add(CreateTile(), 3, 5);
            grid.Add(CreateTile(), 3, 6);
            grid.Add(CreateTile(), 1, 7);
            grid.Add(CreateTile(), 2, 7);
            grid.Add(CreateTile(), 3, 7);
            grid.Add(CreateTile(), 4, 7);
            grid.Add(CreateTile(), 5, 7);
        }

        public void WriteTwo(Grid grid)
        {
            grid.Add(CreateTile(), 2, 1);
            grid.Add(CreateTile(), 3, 1);
            grid.Add(CreateTile(), 4, 1);
            grid.Add(CreateTile(), 1, 2);
            grid.Add(CreateTile(), 5, 2);
            grid.Add(CreateTile(), 5, 3);
            grid.Add(CreateTile(), 4, 4);
            grid.Add(CreateTile(), 3, 5);
            grid.Add(CreateTile(), 2, 6);
            grid.Add(CreateTile(), 1, 7);
            grid.Add(CreateTile(), 2, 7);
            grid.Add(CreateTile(), 3, 7);
            grid.Add(CreateTile(), 4, 7);
            grid.Add(CreateTile(), 5, 7);
        }

        public void WriteThree(Grid grid)
        {
            grid.Add(CreateTile(), 2, 1);
            grid.Add(CreateTile(), 3, 1);
            grid.Add(CreateTile(), 4, 1);
            grid.Add(CreateTile(), 1, 2);
            grid.Add(CreateTile(), 5, 2);
            grid.Add(CreateTile(), 5, 3);
            grid.Add(CreateTile(), 4, 4);
            grid.Add(CreateTile(), 5, 5);
            grid.Add(CreateTile(), 1, 6);
            grid.Add(CreateTile(), 5, 6);
            grid.Add(CreateTile(), 2, 7);
            grid.Add(CreateTile(), 3, 7);
            grid.Add(CreateTile(), 4, 7);
        }

        public void WriteFour(Grid grid)
        {
            grid.Add(CreateTile(), 1, 1);
            grid.Add(CreateTile(), 5, 1);
            grid.Add(CreateTile(), 1, 2);
            grid.Add(CreateTile(), 5, 2);
            grid.Add(CreateTile(), 1, 3);
            grid.Add(CreateTile(), 5, 3);
            grid.Add(CreateTile(), 1, 4);
            grid.Add(CreateTile(), 2, 4);
            grid.Add(CreateTile(), 3, 4);
            grid.Add(CreateTile(), 4, 4);
            grid.Add(CreateTile(), 5, 4);
            grid.Add(CreateTile(), 5, 5);
            grid.Add(CreateTile(), 5, 6);
            grid.Add(CreateTile(), 5, 7);
        }

        public void WriteFive(Grid grid)
        {
            grid.Add(CreateTile(), 1, 1);
            grid.Add(CreateTile(), 2, 1);
            grid.Add(CreateTile(), 3, 1);
            grid.Add(CreateTile(), 4, 1);
            grid.Add(CreateTile(), 5, 1);
            grid.Add(CreateTile(), 1, 2);
            grid.Add(CreateTile(), 1, 3);
            grid.Add(CreateTile(), 2, 4);
            grid.Add(CreateTile(), 3, 4);
            grid.Add(CreateTile(), 4, 4);
            grid.Add(CreateTile(), 5, 5);
            grid.Add(CreateTile(), 1, 6);
            grid.Add(CreateTile(), 5, 6);
            grid.Add(CreateTile(), 2, 7);
            grid.Add(CreateTile(), 3, 7);
            grid.Add(CreateTile(), 4, 7);
        }

        public void WriteSix(Grid grid)
        {
            grid.Add(CreateTile(), 2, 1);
            grid.Add(CreateTile(), 3, 1);
            grid.Add(CreateTile(), 4, 1);
            grid.Add(CreateTile(), 1, 2);
            grid.Add(CreateTile(), 5, 2);
            grid.Add(CreateTile(), 1, 3);
            grid.Add(CreateTile(), 1, 4);
            grid.Add(CreateTile(), 2, 4);
            grid.Add(CreateTile(), 3, 4);
            grid.Add(CreateTile(), 4, 4);
            grid.Add(CreateTile(), 1, 5);
            grid.Add(CreateTile(), 5, 5);
            grid.Add(CreateTile(), 1, 6);
            grid.Add(CreateTile(), 5, 6);
            grid.Add(CreateTile(), 2, 7);
            grid.Add(CreateTile(), 3, 7);
            grid.Add(CreateTile(), 4, 7);
        }

        public void WriteSeven(Grid grid)
        {
            grid.Add(CreateTile(), 1, 1);
            grid.Add(CreateTile(), 2, 1);
            grid.Add(CreateTile(), 3, 1);
            grid.Add(CreateTile(), 4, 1);
            grid.Add(CreateTile(), 5, 1);
            grid.Add(CreateTile(), 5, 2);
            grid.Add(CreateTile(), 5, 3);
            grid.Add(CreateTile(), 4, 4);
            grid.Add(CreateTile(), 3, 5);
            grid.Add(CreateTile(), 2, 6);
            grid.Add(CreateTile(), 1, 7);
        }

        public void WriteEight(Grid grid)
        {
            grid.Add(CreateTile(), 2, 1);
            grid.Add(CreateTile(), 3, 1);
            grid.Add(CreateTile(), 4, 1);
            grid.Add(CreateTile(), 1, 2);
            grid.Add(CreateTile(), 5, 2);
            grid.Add(CreateTile(), 1, 3);
            grid.Add(CreateTile(), 5, 3);
            grid.Add(CreateTile(), 2, 4);
            grid.Add(CreateTile(), 3, 4);
            grid.Add(CreateTile(), 4, 4);
            grid.Add(CreateTile(), 1, 5);
            grid.Add(CreateTile(), 5, 5);
            grid.Add(CreateTile(), 1, 6);
            grid.Add(CreateTile(), 5, 6);
            grid.Add(CreateTile(), 2, 7);
            grid.Add(CreateTile(), 3, 7);
            grid.Add(CreateTile(), 4, 7);

        }

        public void WriteNine(Grid grid)
        {
            grid.Add(CreateTile(), 2, 1);
            grid.Add(CreateTile(), 3, 1);
            grid.Add(CreateTile(), 4, 1);
            grid.Add(CreateTile(), 1, 2);
            grid.Add(CreateTile(), 5, 2);
            grid.Add(CreateTile(), 1, 3);
            grid.Add(CreateTile(), 5, 3);
            grid.Add(CreateTile(), 2, 4);
            grid.Add(CreateTile(), 3, 4);
            grid.Add(CreateTile(), 4, 4);
            grid.Add(CreateTile(), 5, 4);
            grid.Add(CreateTile(), 5, 5);
            grid.Add(CreateTile(), 1, 6);
            grid.Add(CreateTile(), 5, 6);
            grid.Add(CreateTile(), 2, 7);
            grid.Add(CreateTile(), 3, 7);
            grid.Add(CreateTile(), 4, 7);
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
