namespace MathQuizGame;

public partial class Form1 : Form
{
    private const string Version = "Alpha 1.0";
    private const int WindowLength = 1200;
    private const int WindowHeight = 800;
    public Form1()
    {
        InitializeComponent();
        AdjustWindowDimensions(WindowLength,WindowHeight);
        SetWindowTitle("Infinite Math Quiz " + Version);
        LoadStartButton();
        LoadCreditsButton();
        LoadTitle();
        LoadVersionLabel();
        LoadImage();
    }

    private void LoadImage()
    {
        PictureBox picture = new PictureBox();
        picture.Image = Image.FromFile(@"C:\Users\Tim Tran\RiderProjects\MathQuizGame\MathQuizGame\infinity.png");
        picture.SizeMode = PictureBoxSizeMode.StretchImage;
        picture.Size = new Size(400, 150);
        int xPos = (Width - picture.Width) / 2;
        int yPos = (Height - picture.Height) / 2;
        picture.Location = new Point(xPos, yPos -150);
        Controls.Add(picture);
    }
    private void AdjustWindowDimensions(int inLength, int inWidth)
    {
        Size = new System.Drawing.Size(inLength, inWidth);
    }
    
    private void SetWindowTitle(string inTitle)
    {
        Text = inTitle;
    }

    private void LoadStartButton()
    {
        Button button = new Button();
        const int fontSize = 27;
        Controls.Add(button);
        button.Text = "Start";
        button.Font = new Font(button.Font.FontFamily, fontSize, FontStyle.Regular);
        button.Size = new Size(200, 100);
        int xPos = (Width - button.Width) / 2;
        int yPos = (Height - button.Height) / 2;
        button.Location = new Point(xPos, yPos);
        button.Click += StartButton_Click;
    }
    
    private void StartButton_Click(object sender, System.EventArgs e)  
    {  
        Console.WriteLine("Start Button Clicked");
        SettingsForm settings = new SettingsForm(this);
        Hide();
    }  

    private void LoadVersionLabel()
    {
        const int fontSize = 16;
        Label title = new Label();
        Controls.Add(title);
        title.Text = Version;
        title.AutoSize = true;
        title.Font = new Font(title.Font.FontFamily, fontSize, FontStyle.Regular);
        int xPos = (Width - title.Width) / 2;
        int yPos = (Height - title.Height) / 2;
        title.Location = new Point(xPos, yPos +320);
    }

    private void LoadTitle()
    {
        const int fontSize = 32;
        Label title = new Label();
        Controls.Add(title);
        title.Text = "Infinite Math Quiz";
        title.AutoSize = true;
        title.Font = new Font(title.Font.FontFamily, fontSize, FontStyle.Regular);
        int xPos = (Width - title.Width) / 2;
        int yPos = (Height - title.Height) / 2;
        title.Location = new Point(xPos, yPos -300);
    }

    private void LoadCreditsButton()
    {
        const int fontSize = 27;
        Button creditsButton = new Button();
        Controls.Add(creditsButton);
        creditsButton.Text = "Credits";
        creditsButton.Font = new Font(creditsButton.Font.FontFamily, fontSize, FontStyle.Regular);
        creditsButton.Size = new Size(200, 100);
        int xPos = (Width - creditsButton.Width) / 2;
        int yPos = (Height - creditsButton.Height) / 2;
        creditsButton.Location = new Point(xPos, yPos + 160);
        creditsButton.Click += CreditsButton_Clicked!;
    }

    private void CreditsButton_Clicked(object sender, System.EventArgs e)
    {
        Console.WriteLine("Credits Button Clicked");
        CreditsMenu menu = new CreditsMenu(this);
        Hide();
    }
}