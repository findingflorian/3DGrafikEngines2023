using OpenTK.Mathematics;
using _3DEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using OpenTK.Graphics.OpenGL;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DEngine
{
    public partial class Transformation : UserControl
    {

        public GameObject gameObj;



        float scaleXValue = 1, scaleYValue = 1, scaleZValue = 1, translationXValue = 0, translationYValue = 0, translationZValue = 0;

        public Matrix4 localTransform = Matrix4.Identity; //translate * rotate * scale
        private Matrix4 rXMat = Matrix4.Identity;
        private Matrix4 rYMat = Matrix4.Identity;
        private Matrix4 rZMat = Matrix4.Identity;



        public Matrix4 transformationData
        {
            get
            {
                return localTransform;
            }
        }

        public Transformation()
        {
            InitializeComponent();
       
        }

        public Transformation (GameObject gameObj)
        {
            InitializeComponent ();
            this.gameObj = gameObj;
        }

        private void onTranslationChanged(object sender, EventArgs e)
        {
            NumericUpDown obj = sender as NumericUpDown;
            switch (obj.Tag)
            {
                case "rotate_x":
                    this.rXMat = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(numericFormat(obj, 360)));
                    break;
                case "rotate_y":
                    this.rYMat = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(numericFormat(obj, 360)));
                    break;
                case "rotate_z":
                    this.rZMat = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(numericFormat(obj, 360)));
                    break;
                case "scale_x":
                    this.scaleXValue = (float)obj.Value;
                    break;
                case "scale_y":
                    this.scaleYValue = (float)obj.Value;
                    break;
                case "scale_z":
                    this.scaleZValue = (float)obj.Value;
                    break;
                case "translate_x":
                    this.translationXValue = (float)obj.Value;
                    break;
                case "translate_y":
                    this.translationYValue = (float)obj.Value;
                    break;
                case "translate_z":
                    this.translationZValue = (float)obj.Value;
                    break;

            }
            this.updateLocalTransform();

        }

        public float numericFormat(NumericUpDown ctrl, float switchValue)
        {
            float value = (float)ctrl.Value;
            if (Math.Abs(value) >= switchValue)
            {
                value = 0;
                ctrl.Value = 0;
                return value;
            }
            return value;
        }
        public void updateLocalTransform()
        {
            Matrix4 trMat = Matrix4.CreateTranslation(this.translationXValue, this.translationYValue, this.translationZValue);
            Matrix4 scaleMat = Matrix4.CreateScale(this.scaleXValue, this.scaleYValue, this.scaleZValue);

            this.localTransform = rXMat * rYMat * rZMat * trMat * scaleMat;
        }
    }
}
