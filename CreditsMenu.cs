
namespace MathQuizGame;

public partial class CreditsMenu : Form
{
    private const int WindowLength = 1200;
    private const int WindowHeight = 800;
    private Form1 mainMenu;
    public CreditsMenu(Form1 inObject)
    {
        InitializeComponent();
        mainMenu = inObject;
        AdjustWindowDimensions(WindowLength, WindowHeight);
        LoadNames();
        LoadCreditsMTitle();
        LoadMainMenuButton();
        Show();
        FormClosing += CreditsMenu_FormClosing;
    }

    private void LoadCreditsMTitle()
    {
        int fontSize = 32;
        Label title = new Label();
        Controls.Add(title);
        title.AutoSize = true;
        title.Text = "Credits";
        title.Font = new Font(title.Font.FontFamily, fontSize, FontStyle.Regular);
        title.Location = new Point((Width - title.Width) / 2, 0);
    }
    
    private void AdjustWindowDimensions(int inLength, int inWidth)
    {
        Size = new System.Drawing.Size(inLength, inWidth);
    }

    private void LoadNames()
    {
        int fontSize = 32;
        Label name1 = new Label();
        name1.AutoSize = true;
        name1.Text = "Tim Tran, Lead Programmer";
        name1.Font = new Font(name1.Font.FontFamily, fontSize, FontStyle.Regular);
        name1.Location = new Point(0, 100);
        
        Label name2 = new Label();
        name2.AutoSize = true;
        name2.Text = "Aaron Nguyen, Programmer and QA";
        name2.Font = new Font(name2.Font.FontFamily, fontSize, FontStyle.Regular);
        name2.Location = new Point(0, 200);
        
        Controls.Add(name1);
        Controls.Add(name2);
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

    //if user closes the window, the entire application is disposed
    private void CreditsMenu_FormClosing(object sender, FormClosingEventArgs e)
    { 
        mainMenu.Dispose();
    }
    
    //if user presses the Main Menu button, return back
    private void MenuButton_Clicked(object sender, System.EventArgs e)
    {
        mainMenu.Show();
        Dispose();
    }
}