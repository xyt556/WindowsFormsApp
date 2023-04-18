using System.Windows.Forms;
using SharpMap.Layers;
using SharpMap.Data.Providers;
namespace SharpMapExample
{
    
    public partial class MainForm : Form
    {
       
        

        public MainForm()
        {
            InitializeComponent();

            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 创建一个新的地图实例
            var map = new SharpMap.Map(pictureBox1.Size);

            // 添加一个矢量图层
            var layer = new VectorLayer("States");
            layer.DataSource = new ShapeFile("path\\to\\states_ugl.shp", true);
            map.Layers.Add(layer);

            // 设置地图的缩放级别和中心点
            map.ZoomToExtents();
            map.Zoom *= 0.8;
            map.Center = new GeoAPI.Geometries.Coordinate(-96.8, 38.8);

            // 将地图渲染到PictureBox控件中
            pictureBox1.Image = map.GetMap();
        }
    }
}
