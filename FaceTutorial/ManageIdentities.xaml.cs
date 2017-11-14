using Microsoft.ProjectOxford.Face;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;

namespace FaceTutorial
{
    /// <summary>
    /// Interaction logic for ManageIdentities.xaml
    /// </summary>
    public partial class ManageIdentities : Window
    {
        // Replace the first parameter with your valid subscription key.
        //
        // Replace or verify the region in the second parameter.
        //
        // You must use the same region in your REST API call as you used to obtain your subscription keys.
        // For example, if you obtained your subscription keys from the westus region, replace
        // "westcentralus" in the URI below with "westus".
        //
        // NOTE: Free trial subscription keys are generated in the westcentralus region, so if you are using
        // a free trial subscription key, you should not need to change this region.
        private readonly IFaceServiceClient faceServiceClient =
            new FaceServiceClient(ConfigurationManager.AppSettings["subscriptionKey"], ConfigurationManager.AppSettings["apiUrl"]);

        public ManageIdentities()
        {
            InitializeComponent();
        }

        private async void btn_createPersonGroup_Click(object sender, RoutedEventArgs e)
        {
            var personGroupName = await CreatePersonGroup("drivers_group_1", "Drivers Group 1");

            //faceDescriptionStatusBar.Text = personGroupName;
        }

        private async Task<string> CreatePersonGroup(string personGroupId, string personGroupName)
        {
            await faceServiceClient.CreatePersonGroupAsync(personGroupId, personGroupName).ConfigureAwait(false);

            var personGroup = await faceServiceClient.GetPersonGroupAsync(personGroupId).ConfigureAwait(false);

            return personGroup.Name;
        }

    }
}
