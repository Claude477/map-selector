using System; 
using System.Drawing;
using System.Linq;
using System.Windows.Forms; 

namespace koe2
{
    public partial class Form1 : Form
    {
        private int counter=0;
        private string txt = "Selecting map"; 
        private PictureBox picture = new PictureBox{   Size = new Size(500, 500),Location = new Point(10,10)               };
        private Button Back = new Button{};
        private Button Next = new Button{};
        private Label myLabel = new Label();
        PictureBox GetPicture(PictureBox picture){            picture.ImageLocation = files[counter];            return picture;        }
        public Form1()        {            InitializeComponent();      }
        public void Mybuttons()
        {
        // Creating and setting the properties of Button 
        Back.Location = new Point(10, 10); 
        Back.Text = "Back"; 
        Back.AutoSize = true; 
        Back.BackColor = Color.LightBlue; 
        Back.Padding = new Padding(6); 
        Back.Font = new Font("French Script MT", 18); 

        // Add a Button Click Event handler
        Back.Click += new EventHandler(Back_click);
  
        // Adding this button to form 
        this.Controls.Add(Back); 
  
        // Creating and setting the properties of Button 
        Next.Location = new Point(400, 10); 
        Next.Text = "Next"; 
        Next.AutoSize = true; 
        Next.BackColor = Color.LightPink; 
        Next.Padding = new Padding(6); 
        Next.Font = new Font("French Script MT", 18); 

        // Add a Button Click Event handler
        Next.Click += new EventHandler(Next_click);

        // Adding this button to form 
        this.Controls.Add(Next); 
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // Creating and setting the properties of label 
        myLabel.AutoSize = true; 
        myLabel.Text = txt; 
        myLabel.Location = new Point(200, 10); 
        myLabel.Font = new Font("French Script MT", 18); 
        // Adding this label to form 
        this.Controls.Add(myLabel); 
        Back.Enabled=false; 
        
        Mybuttons();
        }
        
        String[] files = System.IO.Directory.GetFiles(@".\\obj\\img");

        public Form1(string[] files)
        {
            this.files = files;
        }
        public void Next_click(object sender, EventArgs e)
        {
            counter = counter + 1;
            if(counter > 0){Back.Enabled=true;}
            if(counter==files.Count()-1){Next.Enabled=false;}
            GetPicture(picture);
            this.Controls.Add(picture);
        }
        public void Back_click(object sender, EventArgs e)
        {
            counter = counter - 1;
            if(counter == 0){Back.Enabled=false;}
            if(counter<files.Count()){Next.Enabled=true;}
            GetPicture(picture);
            this.Controls.Add(picture);
        }
}
}