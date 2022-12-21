using KSR.Model;

namespace KSR
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

           
            EventTree tree= EventTreeFactory.CreateTree(EventTreeType.Factory);
        }
    }
}