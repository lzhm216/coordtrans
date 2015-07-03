using System;
using System.Collections.Generic;
using System.Text;

namespace CoordTransfer
{
    public enum ProjectType
    {
        Gs3,
        Gs6,
        Utm,
        Unknown
    }

    public class Project
    {
        string infileName;
        string outfileName;
        string outcoorSys;
        string resultStr;

        public Project()
        {
            this.infileName = string.Empty;
            this.outfileName = string.Empty;
            this.outcoorSys = string.Empty;
            this.resultStr = string.Empty;
        }

        public Project(string infileName, string outfileName, string outcoorSys)
        {
            this.infileName = infileName;
            this.outfileName = outfileName;
            this.outcoorSys = outcoorSys;
            this.resultStr = string.Empty;
        }

        public string InFileName
        {
            get { return this.infileName; }
            set { this.infileName = value; }
        }

        public string OutFileName
        {
            get { return this.outfileName; }
            set { this.outfileName = value; }

        }

        public string OutCoorSys
        {
            get { return this.outcoorSys; }
            set { this.outcoorSys = value; }
        }
        public string ResultString
        {
            get { return this.resultStr; }
            set { this.resultStr = value; }
        }

        public void Run()
        {
            if (this.infileName == string.Empty || this.outfileName == string.Empty) return;
            if (this.outcoorSys == string.Empty) return;

            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;

            ESRI.ArcGIS.DataManagementTools.Project project = new ESRI.ArcGIS.DataManagementTools.Project();

            IGeoProcessorResult result;

            project.in_dataset = infileName;

            project.out_dataset = outfileName;

            project.out_coor_system = this.outcoorSys;

            result = (IGeoProcessorResult)gp.Execute(project, null);


            if (result != null)
            {
                this.resultStr = "投影完成";
            }
            else
            {
                this.resultStr = "投影失败";
            }
        }


        /// <summary>
        /// 另一种方法
        /// </summary>
        //public void Run1()
        //{
        ////方法二：调用接口处理文件的投影转换


        //IWorkspaceFactory shapefileworkspaceF = new ShapefileWorkspaceFactoryClass();
        //IWorkspace workspace = shapefileworkspaceF.OpenFromFile(inWorkspaceName, 0);
        //IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
        //IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(inFileName) as IFeatureClass;

        //ISpatialReference pspatialref = (ISpatialReference)featureClass.GetFeature(0).Shape.SpatialReference;

        ////获取输出文件名
        //string outFeatureClassname = pSavefilename.Remove(0, pSavefilename.LastIndexOf("\\") + 1);
        //outFeatureClassname = outFeatureClassname.Replace(".shp", "");

        ////获取输出文件的路径
        //string outworkspaceName = pSavefilename.Remove(pSavefilename.LastIndexOf("\\"));

        //IWorkspace outworkspace = shapefileworkspaceF.OpenFromFile(outworkspaceName, 0);
        //IFeatureWorkspace outFeatureWorkspace = workspace as IFeatureWorkspace;

        //IFields outFields = new FieldsClass();
        //IFieldsEdit outFieldsEdit = (IFieldsEdit)outFields;

        //IField outField = new FieldClass();

        //IFields inFields = featureClass.Fields;

        //ISpatialReference outSpatialref=new SpatialReferenceEnvironmentClass();

        //for (int i = 0; i < inFields.FieldCount; i++)
        //{
        //    outField = inFields.get_Field(i);
        //    if (outField.Name == "Shape")
        //    {
        //        IFieldEdit outFieldEdit = (IFieldEdit)outField;
        //        IGeometryDef geometryDef = outField.GeometryDef;
        //        IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
        //        geometryDefEdit.SpatialReference_2
        //    }
        //    outFieldsEdit.AddField(outField);
        //}

        //IFeatureClass outFeatureclass = outFeatureWorkspace.CreateFeatureClass(outFeatureClassname, outFields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
        //}


    }

    //清除坐标系统
    public class ClearCoorSystem
    {
        string shapefileName;
        string workspaceName;

        public string ShapefileName
        {
            get { return this.shapefileName; }
            set { this.shapefileName = value; }
        }

        public string WorkspaceName
        {
            get { return this.workspaceName; }
            set { this.workspaceName = value; }
        }

        public ClearCoorSystem()
        {
            shapefileName = "";
            workspaceName = "";
        }

        public void Run()
        {
            IWorkspaceFactory shapefileworkspaceF = new ShapefileWorkspaceFactoryClass();

            IWorkspace workspace = shapefileworkspaceF.OpenFromFile(workspaceName, 0);

            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;

            IFeatureClass pFeatureClass = featureWorkspace.OpenFeatureClass(shapefileName) as IFeatureClass;

            ISpatialReference pSpatialref = new UnknownCoordinateSystemClass();

            for (int i = 0; i < pFeatureClass.FeatureCount(null); i++)
            {
                IFeature pFeature = (IFeature)pFeatureClass.GetFeature(i);
                pFeature.Shape.SpatialReference = pSpatialref;
                pFeature.Store();
            }
            
        }

    }

    public class DefineCoorSystem
    {
        string fileName;
        string coorSystemStr;
        string defResult;

        public DefineCoorSystem()
        {
            this.fileName = "";
            this.coorSystemStr = "";
            this.defResult = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">文件所在目录</param>
        /// <param name="coorSystemStr">坐标系统参数</param>
        public DefineCoorSystem(string fileName, string coorSystemStr)
        {
            this.fileName = fileName;
            this.coorSystemStr = coorSystemStr;
        }

        public string FileName
        {
            set { this.coorSystemStr = value; }
        }

        public string CoorSystemStr
        {
            set { this.coorSystemStr = value; }
        }

        public string DefineResult
        {
            get { return this.defResult; }
        }

        public void Run()
        {
            if (this.fileName == string.Empty || this.coorSystemStr == string.Empty) return;
            if (!System.IO.Directory.Exists(fileName)) return;

            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;

            DefineProjection defPrj = new DefineProjection();

            IGeoProcessorResult result;

            defPrj.in_dataset = this.fileName;

            defPrj.out_dataset = this.fileName;

            defPrj.coor_system = this.coorSystemStr;

            result = (IGeoProcessorResult)gp.Execute(defPrj, null);


            if (result != null)
            {
                this.defResult = "成功定义坐标系统";
            }
            else
            {
                this.defResult = "定义坐标系统失败";
            }

        }
    }

    public class ShapefileTransfer4
    {
        string shapefileName;
        string workspaceName;
        IPoint[] fromPoints;
        IPoint[] toPoints;

        public ShapefileTransfer4()
        {
            shapefileName = "";
            workspaceName = "";
        }

        public string ShapeFileName
        {
            get { return this.shapefileName; }
            set { this.shapefileName = value; }
        }

        public string WorkspaceName
        {
            get { return this.workspaceName; }
            set { this.workspaceName = value; }
        }

        public IPoint[] FromPoints
        {
            get { return this.fromPoints; }
            set { this.fromPoints = value; }
        }

        public IPoint[] ToPoints
        {
            get { return this.toPoints; }
            set { this.toPoints = value; }
        }

        public void transform2D()
        {
            
            IAffineTransformation2D3GEN affineTransformation2D = new AffineTransformation2DClass();

            affineTransformation2D.DefineFromControlPoints(ref fromPoints, ref toPoints);


            //单点转换
            //double[] inPoints = new double[3];
            //double[] outPoints = new double[3];

            //inPoints[0] = 501557.117;
            //inPoints[1] = 4041000.863;
            //inPoints[2] = 1651.875;

            //affineTransformation2D.TransformPointsFF(esriTransformDirection.esriTransformForward, ref inPoints, ref outPoints);



            IWorkspaceFactory shapefileworkspaceF = new ShapefileWorkspaceFactoryClass();

            IWorkspace workspace = shapefileworkspaceF.OpenFromFile(workspaceName, 0);

            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;

            IFeatureClass pFeatureClass = featureWorkspace.OpenFeatureClass(shapefileName) as IFeatureClass;

            IFeatureClass pFeatureClass1 = featureWorkspace.CreateFeatureClass("test", pFeatureClass.Fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");

            for (int i = 0; i < pFeatureClass.FeatureCount(null); i++)
            {
                IFeature pFeature = (IFeature)pFeatureClass.GetFeature(i);
                IFeature pFeature1 = pFeatureClass1.CreateFeature();
                pFeature1.Shape = pFeature.ShapeCopy;

                IGeometry pGeometry = (IGeometry)pFeature1.Shape;
                
                ITransform2D transform2D = pGeometry as ITransform2D;
                transform2D.Transform(esriTransformDirection.esriTransformForward, affineTransformation2D as ITransformation);

                pFeature1.Store();
            }

            
        }

    }

    public class ShapefileTransfer7
    {
        string shapefileName;
        string workspaceName;
        IPoint[] fromPoints;
        IPoint[] toPoints;

        public ShapefileTransfer7()
        {
            shapefileName = "";
            workspaceName = "";
        }

        public string ShapeFileName
        {
            set { this.shapefileName = value; }
        }

        public string WorkspaceName
        {
            set { this.workspaceName = value; }
        }

        public IPoint[] FromPoints
        {
            set { this.fromPoints = value; }
        }

        public IPoint[] ToPoints
        {
            set { this.toPoints = value; }
        }

        public void transform3D()
        {

            IAffineTransformation3DGEN affineTransformation3D = new AffineTransformation3DClass();

            affineTransformation3D.DefineFromControlPoints(ref fromPoints, ref toPoints);


            //单点转换
            //double[] inPoints = new double[3];
            //double[] outPoints = new double[3];

            //inPoints[0] = 501557.117;
            //inPoints[1] = 4041000.863;
            //inPoints[2] = 1651.875;

            //affineTransformation3D.TransformPointsFF(esriTransformDirection.esriTransformForward, ref inPoints, ref outPoints);

            //
            //double fromerr=0;
            //double toerr = 0;
            //for (int i = 0; i < fromPoints.Length; i++)
            //{
            //    affineTransformation3D.GetControlPointError(i, ref fromerr, ref toerr);
            //    Console.WriteLine("{0},{1}", fromerr, toerr);
            //}

            IWorkspaceFactory shapefileworkspaceF = new ShapefileWorkspaceFactoryClass();

            IWorkspace workspace = shapefileworkspaceF.OpenFromFile(workspaceName, 0);

            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;

            IFeatureClass pFeatureClass = featureWorkspace.OpenFeatureClass(shapefileName) as IFeatureClass;

            IFeatureClass pFeatureClass1 = featureWorkspace.CreateFeatureClass("test1", pFeatureClass.Fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
            
            for (int i = 0; i < pFeatureClass.FeatureCount(null); i++)
            {
                IFeature pFeature = (IFeature)pFeatureClass.GetFeature(i);

                IFeature pFeature1 = pFeatureClass1.CreateFeature();

                IGeometry pGeometry = (IGeometry)pFeature1.Shape;

                ITransform3D transform3D = pGeometry as ITransform3D;

                transform3D.Transform3D(esriTransformDirection.esriTransformForward, affineTransformation3D as ITransformation3D);

                pFeature1.Store();
            }


        }

        
    }
}
