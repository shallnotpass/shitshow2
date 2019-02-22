
// Copyright (C) 2016-2017 Luca Piccioni
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Windows;
using System.Windows.Forms;

using OpenGL;

namespace HelloTriangle.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
        private void draw()
        {
            double[] cx = new double[70];
            double[] cy = new double[70];
            for (var i = 0; i < 64; i++)
            {
                int angle = 360 * i / 63;  // Or perhaps 2 * PI * i / 63
                cx[i] = Math.Sin(angle);
                cy[i] = Math.Cos(angle);
            }
            for (var i = 0; i < 63; i++)
            {
                Gl.Vertex3(cx[i], cy[i], 0);
                Gl.Vertex3(cx[i + 1], cy[i + 1], 0);
                Gl.Vertex3(cx[i], cy[i], 1);
                Gl.Vertex3(cx[i + 1], cy[i + 1], 1);

                //Gl.DrawTriangle(v0, v1, v2);
                // DrawTriangle(v1, v3, v2);
                using (MemoryLock vertexArrayLock = new MemoryLock(_ArrayPosition))
                using (MemoryLock vertexColorLock = new MemoryLock(_ArrayColor))
                {
                    // Note: the use of MemoryLock objects is necessary to pin vertex arrays since they can be reallocated by GC
                    // at any time between the Gl.VertexPointer execution and the Gl.DrawArrays execution

                    Gl.VertexPointer(2, VertexPointerType.Float, 0, vertexArrayLock.Address);
                    Gl.EnableClientState(EnableCap.VertexArray);

                    Gl.ColorPointer(3, ColorPointerType.Float, 0, vertexColorLock.Address);
                    Gl.EnableClientState(EnableCap.ColorArray);

                    Gl.DrawArrays(PrimitiveType.Triangles, 0, 3);
                }
                // If you have it:  DrawQuad(v0, v1, v3, v2);
            }
        }
		private void HostControl_Loaded(object sender, RoutedEventArgs e)
		{			
		}

		private void GlControl_ContextCreated(object sender, OpenGL.GlControlEventArgs e)
		{
			Gl.MatrixMode(MatrixMode.Projection);
			Gl.LoadIdentity();
			Gl.Ortho(0.0, 1.0f, 0.0, 1.0, 0.0, 1.0);

			Gl.MatrixMode(MatrixMode.Modelview);
			Gl.LoadIdentity();
		}

		private void GlControl_Render(object sender, OpenGL.GlControlEventArgs e)
		{
            var senderControl = sender as GlControl;
			
			int vpx = 0;
			int vpy = 200;
            int vpw = 100;//senderControl.ClientSize.Width;
            int vph = 200;//senderControl.ClientSize.Height;

			Gl.Viewport(vpx, vpy, vpw, vph);
			Gl.Clear(ClearBufferMask.ColorBufferBit);

			if (Gl.CurrentVersion >= Gl.Version_110)
            {
				// Old school OpenGL 1.1
				// Setup & enable client states to specify vertex arrays, and use Gl.DrawArrays instead of Gl.Begin/End paradigm
				using (MemoryLock vertexArrayLock = new MemoryLock(_ArrayPosition)) 
				using (MemoryLock vertexColorLock = new MemoryLock(_ArrayColor))
				{
					// Note: the use of MemoryLock objects is necessary to pin vertex arrays since they can be reallocated by GC
					// at any time between the Gl.VertexPointer execution and the Gl.DrawArrays execution

					Gl.VertexPointer(2, VertexPointerType.Float, 0, vertexArrayLock.Address);
					Gl.EnableClientState(EnableCap.VertexArray);

					Gl.ColorPointer(3, ColorPointerType.Float, 0, vertexColorLock.Address);
					Gl.EnableClientState(EnableCap.ColorArray);

					Gl.DrawArrays(PrimitiveType.Triangles, 0, 3);
				}
                Gl.Clear(ClearBufferMask.ColorBufferBit);
                this.draw();
            }
            else
            {
				// Old school OpenGL
				Gl.Begin(PrimitiveType.Triangles);
				Gl.Color3(1.0f, 0.0f, 0.0f); Gl.Vertex2(0.0f, 0.0f);
				Gl.Color3(0.0f, 1.0f, 0.0f); Gl.Vertex2(0.5f, 1.0f);
				Gl.Color3(0.0f, 0.0f, 1.0f); Gl.Vertex2(1.0f, 0.0f);
				Gl.End();
			}
		}

		/// <summary>
		/// Vertex position array.
		/// </summary>
		private static readonly float[] _ArrayPosition = new float[]
        {
			0.0f, 0.0f,
			0.5f, 1.0f,
			1.0f, 0.0f
		};

		/// <summary>
		/// Vertex color array.
		/// </summary>
		private static readonly float[] _ArrayColor = new float[]
        {
			1.0f, 0.0f, 0.0f,
			0.0f, 1.0f, 0.0f,
			0.0f, 0.0f, 1.0f
		};
        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void MenuItem_Click2(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}
	}
}
