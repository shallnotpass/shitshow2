using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloTriangle.WPF
{
    class Cylinder
    {
        /* public Cylinder(int n)
         {

             this.numOfVertex = n;

             float[] vertex = new float[3 * (n + 1) * 2];
             byte[] baseIndex = new byte[n];
             byte[] topIndex = new byte[n];
             byte[] edgeIndex = new byte[n * 2 + 2];

             double perAngle = 2 * Math.PI / n;

             for (int i = 0; i < n; i++)
             {
                 double angle = i * perAngle;
                 int offset = 6 * i;

                 vertex[offset + 0] = (float)(Math.Cos(angle) * radious) + cx;
                 vertex[offset + 1] = -height;
                 vertex[offset + 2] = (float)(Math.Sin(angle) * radious) + cy;

                 vertex[offset + 3] = (float)(Math.Cos(angle) * radious) + cx;
                 vertex[offset + 4] = height;
                 vertex[offset + 5] = (float)(Math.Sin(angle) * radious) + cy;

                 topIndex[i] = (byte)(2 * i);

                 baseIndex[i] = (byte)(2 * i + 1);

                 edgeIndex[2 * i + 1] = baseIndex[i];
                 edgeIndex[2 * i] = topIndex[i];

             }


             edgeIndex[2 * n] = topIndex[0];
             edgeIndex[2 * n + 1] = baseIndex[0];

             ByteBuffer vbb = ByteBuffer
                     .allocateDirect(vertex.length * 4)
                     .order(ByteOrder.nativeOrder());

             mFVertexBuffer = vbb.asFloatBuffer();
             mFVertexBuffer.put(vertex);
             mFVertexBuffer.position(0);

             normalBuffer = mFVertexBuffer;

             mCircleBottom = ByteBuffer.allocateDirect(baseIndex.length);
             mCircleBottom.put(baseIndex);
             mCircleBottom.position(0);

             mCircleTop = ByteBuffer.allocateDirect(topIndex.length);
             mCircleTop.put(topIndex);
             mCircleTop.position(0);

             mEdge = ByteBuffer.allocateDirect(edgeIndex.length);
             mEdge.put(edgeIndex);
             mEdge.position(0);
         }

         public void draw(Gl.gl)
         {
             gl.glCullFace(GL10.GL_BACK);
             gl.glEnable(GL10.GL_CULL_FACE);
             gl.glVertexPointer(3, GL10.GL_FLOAT, 0, mFVertexBuffer);
             gl.glNormalPointer(GL10.GL_FLOAT, 0, normalBuffer);
             gl.glEnableClientState(GL10.GL_VERTEX_ARRAY);

             gl.glPushMatrix();

             gl.glColor4f(1f, 0, 0, 0);
             gl.glDrawElements(GL10.GL_TRIANGLE_STRIP, numOfVertex * 2 + 2, GL10.GL_UNSIGNED_BYTE, mEdge);
             gl.glPopMatrix();
             Gl.PopMatrix();
             gl.glPushMatrix();

             gl.glColor4f(0.9f, 0, 0, 0);
             gl.glDrawElements(Gl.TR, numOfVertex, Gl.UNSIGNED_BYTE, mCircleTop);
             gl.glPopMatrix();

             gl.glPushMatrix();

             gl.glTranslatef(0, 2 * height, 0);
             gl.glRotatef(-180, 1, 0, 0);

             gl.glColor4f(0.9f, 0, 0, 0);
             gl.glDrawElements(GL10.GL_TRIANGLE_FAN, numOfVertex, GL10.GL_UNSIGNED_BYTE, mCircleBottom);
             gl.glPopMatrix();

         }

         private float mFVertexBuffer;
         private float normalBuffer;
         private Byte mCircleBottom;
         private Byte mCircleTop;
         private Byte mEdge;
         private int numOfVertex;
         private int cx = 0;
         private int cy = 0;
         private int height = 1;
         private float radious = 1;
         */
    }

}
