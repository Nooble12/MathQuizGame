namespace MathQuizGame;
using System.Timers;
public partial class SettingsForm : Form
{
    private Form1 mainMenu;
    private const int WindowLength = 1200;
    private const int WindowHeight = 800;
    private TextBox box = new TextBox();
    private static System.Timers.Timer aTimer;
    private Label error = new Label();
    
    public SettingsForm(Form1 inObject)
    {
        InitializeComponent();
        AdjustWindowDimensions(WindowLength, WindowHeight);
        mainMenu = inObject;
        LoadSettingsTitle();
        LoadMainMenuButton();
        LoadNextButton();
        LoadTextBox();
        LoadTextBoxLabel();
        FormClosing += Settings_FormClosing;
        Show();
    }
    
    private void AdjustWindowDimensions(int inLength, int inWidth)
    {
        Size = new System.Drawing.Size(inLength, inWidth);
    }

    private void LoadTextBoxLabel()
    {
        int fontSize = 16;
        Label boxLabel = new Label();
        Controls.Add(boxLabel);
        boxLabel.AutoSize = true;
        boxLabel.Text = "Max Operand Value";
        boxLabel.Font = new Font(boxLabel.Font.FontFamily, fontSize, FontStyle.Regular);
        int xPos = (Width - boxLabel.Width) / 2;
        int yPos = (Height - boxLabel.Height) / 2;
        boxLabel.Location = new Point(xPos,yPos - 50);
        Console.Write(boxLabel);
    }

    private void LoadTextBox()
    {
        box.Size = new Size(300, 200);
        int xPos = (Width - box.Width) / 2;
        int yPos = (Height - box.Height) / 2;
        box.Location = new Point(xPos, yPos);
        box.Text = "10";
        Controls.Add(box);
    }

    private void LoadSettingsTitle()
    {
        int fontSize = 32;
        Label title = new Label();
        Controls.Add(title);
        title.AutoSize = true;
        title.Text = "Settings";
        title.Font = new Font(title.Font.FontFamily, fontSize, FontStyle.Regular);
        title.Location = new Point((Width - title.Width) / 2, 0);
    }
    
    private void LoadMainMenuButton()
    { 
        Button menuButton = new Button();
        Controls.Add(menuButton);
        const int fontSize = 27;
        menuButton.Text = "Back";
        menuButton.Font = new Font(menuButton.Font.FontFamily, fontSize, FontStyle.Regular);
        menuButton.Size = new Size(200, 100);
        menuButton.Location = new Point(0, (WindowHeight - menuButton.Height) - 50);
        menuButton.Click += MenuButton_Clicked;
    }
    
    private void LoadNextButton()
    { 
        Button nextButton = new Button();
        Controls.Add(nextButton);
        const int fontSize = 27;
        nextButton.Text = "Next";
        nextButton.Font = new Font(nextButton.Font.FontFamily, fontSize, FontStyle.Regular);
        nextButton.Size = new Size(200, 100);
        nextButton.Location = new Point((Width - nextButton.Width), (Height - nextButton.Height) -50);
        nextButton.Click += NextButton_Clicked;
    }
    
    private void Settings_FormClosing(object sender, FormClosingEventArgs e)
    { 
        mainMenu.Dispose();
    }
    
    //if user presses the Main Menu button, return back
    private void MenuButton_Clicked(object sender, System.EventArgs e)
    {
        mainMenu.Show();
        Dispose();
    }
    
    private void NextButton_Clicked(object sender, System.EventArgs e)
    {
        if (ConvertToInt(box.Text))
        {
            MathQuiz game = new MathQuiz(this);
            Hide();
        }
    }
    
    private void DisplayIntError()
    {
        SetDeleteErrorTimer();
        int fontSize = 16;
        Controls.Add(error);
        error.ForeColor = System.Drawing.Color.Red;
        error.AutoSize = true;
        error.Text = "Invalid Integer";
        error.Font = new Font(error.Font.FontFamily, fontSize, FontStyle.Regular);
        int xPos = (Width - error.Width) / 2;
        int yPos = (Height - error.Height) / 2;
        error.Location = new Point(xPos, yPos + 50);
    }

    private void SetDeleteErrorTimer()
    {
        aTimer = new System.Timers.Timer(2000); // 2 seconds
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = false;
        aTimer.Start();
    }
    
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        error.Text = string.Empty;
        Console.WriteLine("Cleared Text");
    }
    
    private bool ConvertToInt(string inString)
    {
        try
        {
            if (Int32.Parse(inString) > 0)
            {
                int input = Int32.Parse(inString);
                RandomOperand game = new RandomOperand();
                game.SetMaxOperand(input);
                return true;   
            }
            DisplayIntError();
            return false;
        }
        catch (FormatException)
        {
            DisplayIntError();
            return false;
        }
    }
}