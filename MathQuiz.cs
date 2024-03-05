namespace MathQuizGame;
using System.Timers;

public partial class MathQuiz : Form
{
    private SettingsForm _settings;
    private const int WindowLength = 1200;
    private const int WindowHeight = 800;
    private Timer _elapsedTime;
    private readonly Label _timeLabel = new();
    private static int _timeCount;
    private readonly TextBox _box = new();
    
    private Question _question = new Addition();
    private readonly Label _resultLabel = new();
    private readonly Label _questionLabel = new();
    private readonly Label _questionNumberLabel = new();

    private int _questionNumber;
    
    public MathQuiz(SettingsForm inObject)
    {
        InitializeComponent();
        AdjustWindowDimensions(WindowLength, WindowHeight);
        _settings = inObject;
        LoadBackButton();
        FormClosing += SettingsMenu_FormClosing;
        SetElapsedTimer();
        LoadTimeLabel();
        LoadSubmitBox();
        LoadSubmitButton();
        DisplayQuestionNumber();
        Show();
        LoadQuestion();
    }

    private void LoadSubmitBox()
    {
        _box.Size = new Size(400, 200);
        _box.Location = new Point((Width - _box.Width) / 2, (Height - _box.Height) / 2);
        Controls.Add(_box);
    }

    private void LoadSubmitButton()
    {
        Button submitButton = new Button();
        Controls.Add(submitButton);
        const int fontSize = 10;
        submitButton.Text = "Submit";
        submitButton.Font = new Font(submitButton.Font.FontFamily, fontSize, FontStyle.Regular);
        submitButton.Size = new Size(100, 50);
        submitButton.Location = new Point((Width - submitButton.Width) / 2, (Height - submitButton.Height) / 2 + 50);
        submitButton.Click += SubmitButton_Clicked;
    }

    private void SubmitButton_Clicked(object sender, System.EventArgs e)
    {
        try
        { 
            CheckInput(Int32.Parse(_box.Text.Trim()));
        }
        catch (FormatException)
        {
            Console.Write("invalid input");
            DisplayText("Incorrect!", Color.Red);
        }
    }

    private void CheckInput(int inAnswer)
    {
        if (inAnswer == _question.GetAnswer())
        {
            Console.Write("Correct");
            DisplayText("Correct!", Color.LimeGreen);
            ResetTextBox();
            LoadQuestion();
        }

        else
        {
            DisplayText("Incorrect! Answer: " + _question.GetAnswer(), Color.Red);
        }
    }
    
    private void SetElapsedTimer()
    {
        _elapsedTime = new System.Timers.Timer(1000);
        _elapsedTime.Elapsed += OnTimedEvent;
        _elapsedTime.AutoReset = true;
        _elapsedTime.Start();
    }

    private void ResetTextBox()
    {
        _box.Text = String.Empty;
    }

    private void ResetResultText()
    {
        _resultLabel.Text = string.Empty;
    }

    private void DisplayText(String inString, Color inColor)
    {
        SetDeleteTimer();
        _resultLabel.Text = inString;
        _resultLabel.BackColor = inColor;
        _resultLabel.AutoSize = true;
        Controls.Add(_resultLabel);
        const int fontSize = 27;
        _resultLabel.Font = new Font(_resultLabel.Font.FontFamily, fontSize, FontStyle.Regular);
        _resultLabel.Location = new Point((Width - _resultLabel.Width) / 2, (Height - _resultLabel.Height) / 2 + 200);
    }

    private void LoadQuestion()
    {
        _question = new Addition();
        IncrementQuestionNumber();
        DisplayQuestionNumber();
        _questionLabel.AutoSize = true;
        _questionLabel.Text = _question.GetQuestion(); // get question from math.cs
        Controls.Add(_questionLabel);
        const int fontSize = 27;
        _questionLabel.Font = new Font(_questionLabel.Font.FontFamily, fontSize, FontStyle.Regular);
        _questionLabel.Location = new Point((Width - _questionLabel.Width) / 2, (Height - _questionLabel.Height) / 2 - 50);
    }

    private void IncrementQuestionNumber()
    {
        _questionNumber++;
    }

    private void DisplayQuestionNumber()
    {
        int fontSize = 32;
        _questionNumberLabel.Text = "Question #" + _questionNumber;
        Controls.Add(_questionNumberLabel);
        _questionNumberLabel.AutoSize = true;
        _questionNumberLabel.Font = new Font(_questionNumberLabel.Font.FontFamily, fontSize, FontStyle.Regular);
        _questionNumberLabel.Location = new Point((Width - _questionNumberLabel.Width) / 2, 100);
    }
    
    private void AdjustWindowDimensions(int inLength, int inWidth)
    {
        Size = new System.Drawing.Size(inLength, inWidth);
    }
    
    private void SettingsButton_Clicked(object sender, System.EventArgs e)
    {
        ResetTime();
        _settings.Show();
        Dispose();
    }
    
    private void LoadBackButton()
    { 
        Button backButton = new Button();
        Controls.Add(backButton);
        const int fontSize = 27;
        backButton.Text = "Settings";
        backButton.Font = new Font(backButton.Font.FontFamily, fontSize, FontStyle.Regular);
        backButton.Size = new Size(200, 100);
        backButton.Location = new Point(0, (WindowHeight - backButton.Height) - 50);
        backButton.Click += SettingsButton_Clicked;
    }

    private void SetDeleteTimer()
    {
        Timer deleteTimer = new Timer(2000);
        deleteTimer.AutoReset = false;
        deleteTimer.Elapsed += OnTimedDeleteEvent;
        deleteTimer.Start();
    }
    
    private void OnTimedDeleteEvent(Object source, ElapsedEventArgs e)
    {
        ResetResultText();
    }
    
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        _timeCount += 1;
        _timeLabel.Text = "Elapsed Time: " + _timeCount;
    }

    private void LoadTimeLabel()
    {
        int fontSize = 32;
        Controls.Add(_timeLabel);
        _timeLabel.AutoSize = true;
        _timeLabel.Text = "Elapsed Time: 0";
        _timeLabel.Font = new Font(_timeLabel.Font.FontFamily, fontSize, FontStyle.Regular);
        _timeLabel.Location = new Point((Width - _timeLabel.Width) / 2, 0);
    }

    private void ResetTime()
    {
        _elapsedTime.Stop();
        _timeCount = 0;
    }
    
    private void SettingsMenu_FormClosing(object sender, FormClosingEventArgs e)
    { 
        ResetTime();
        Dispose();
        _settings.Show();
    }
}