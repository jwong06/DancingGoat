//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at http://docs.kentico.com.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.DocumentEngine;

[assembly: RegisterDocumentType(AboutUs.CLASS_NAME, typeof(AboutUs))]

namespace CMS.DocumentEngine.Types.DancingGoatMvc
{
    /// <summary>
    /// Represents a content item of type AboutUs.
    /// </summary>
    public partial class AboutUs : TreeNode
    {
        #region "Constants and variables"

        /// <summary>
        /// The name of the data class.
        /// </summary>
        public const string CLASS_NAME = "DancingGoatMvc.AboutUs";


        /// <summary>
        /// The instance of the class that provides extended API for working with AboutUs fields.
        /// </summary>
        private readonly AboutUsFields mFields;

        #endregion


        #region "Properties"

        /// <summary>
        /// AboutUsID.
        /// </summary>
        [DatabaseIDField]
        public int AboutUsID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("AboutUsID"), 0);
            }
            set
            {
                SetValue("AboutUsID", value);
            }
        }


        /// <summary>
        /// Teaser.
        /// </summary>
        [DatabaseField]
        public string AboutUsTeaser
        {
            get
            {
                return ValidationHelper.GetString(GetValue("AboutUsTeaser"), @"");
            }
            set
            {
                SetValue("AboutUsTeaser", value);
            }
        }


        /// <summary>
        /// Gets an object that provides extended API for working with AboutUs fields.
        /// </summary>
        [RegisterProperty]
        public AboutUsFields Fields
        {
            get
            {
                return mFields;
            }
        }


        /// <summary>
        /// Provides extended API for working with AboutUs fields.
        /// </summary>
        [RegisterAllProperties]
        public partial class AboutUsFields : AbstractHierarchicalObject<AboutUsFields>
        {
            /// <summary>
            /// The content item of type AboutUs that is a target of the extended API.
            /// </summary>
            private readonly AboutUs mInstance;


            /// <summary>
            /// Initializes a new instance of the <see cref="AboutUsFields" /> class with the specified content item of type AboutUs.
            /// </summary>
            /// <param name="instance">The content item of type AboutUs that is a target of the extended API.</param>
            public AboutUsFields(AboutUs instance)
            {
                mInstance = instance;
            }


            /// <summary>
            /// AboutUsID.
            /// </summary>
            public int ID
            {
                get
                {
                    return mInstance.AboutUsID;
                }
                set
                {
                    mInstance.AboutUsID = value;
                }
            }


            /// <summary>
            /// Teaser.
            /// </summary>
            public string Teaser
            {
                get
                {
                    return mInstance.AboutUsTeaser;
                }
                set
                {
                    mInstance.AboutUsTeaser = value;
                }
            }
        }

        #endregion


        #region "Constructors"

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutUs" /> class.
        /// </summary>
        public AboutUs() : base(CLASS_NAME)
        {
            mFields = new AboutUsFields(this);
        }

        #endregion
    }
}