using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE;
using System.Windows.Forms;

namespace ICC.Shared.PipelineComponents
{
    public class Wizard : IWizard
    {

        private string shared_ass_name = "ICC.Shared.PipelineComponents";
        private string newDestinationDirectory = String.Empty;
        private string newProjectname = String.Empty;

        // C:\work\uu-integration-biztalk\ICC.Shared.PipelineComponents\Template\Wizard\ICC.Shared.PipelineComponents.Wizard.dll
        // This method is called before opening any item that   
        // has the OpenInEditor attribute.  
        public void BeforeOpeningFile(ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(Project project)
        {
        
           //ICC.Shared.PipelineComponents
           if (!project.Name.Contains("."))
                project.Name = String.Format("{0}.{1}", shared_ass_name, project.Name);
        }

        // This method is only called for item templates,  
        // not for project templates.  
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {
            
        }

        // This method is called after the project is created.  
        public void RunFinished()
        {
           
        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {

           
            
            

            try
            {
                string projectname = replacementsDictionary["$safeprojectname$"];
                string  componentName = "component";

                if (projectname.Contains("."))
                {
                    ComponentName componentDialog = new ComponentName();

                    if (componentDialog.ShowDialog() == DialogResult.OK)
                    {

                        componentName = componentDialog.txtName.Text;
                    }
                    
                    componentDialog.Dispose();

                    // Add custom parameters.  
                    replacementsDictionary.Add("$componentname$", componentName);

                //    replacementsDictionary.Add("$componentns$",projectName);



                }
                else//shared pipelinecomponent. Only component name can be specified
                {
                    
                    replacementsDictionary["$safeprojectname$"] = String.Format("{0}.{1}", shared_ass_name, projectname);

                    // Add custom parameters.  
                    replacementsDictionary.Add("$componentname$",
                        projectname);
                 
                }
                 

              



               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // This method is only called for item templates,  
        // not for project templates.  
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
