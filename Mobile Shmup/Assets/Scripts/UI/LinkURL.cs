using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.UI
{
    public class LinkURL : MonoBehaviour
    {
        public void GoToLink(string url)
        {
            Application.OpenURL(url);
        }
    }
}
