//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "10.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LainsaSciExtranet {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LainsaSciExtranet() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.LainsaSciExtranet", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to En esta página podrá acceder a los documentos para los que se encuentra autorizado.&lt;/br&gt; Haga clic en los nodos del árbol a la izquierda para acceder a los diferentes elementos..
        /// </summary>
        internal static string Bienvenida {
            get {
                return ResourceManager.GetString("Bienvenida", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuario o contraseña incorrectos.
        /// </summary>
        internal static string FalloLogin {
            get {
                return ResourceManager.GetString("FalloLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe marcar la revisión antes de aceptar.
        /// </summary>
        internal static string MarcarRevision {
            get {
                return ResourceManager.GetString("MarcarRevision", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Se ha enviado un correo a la dirección {0} en la que figuran los datos de acceso a nuestra extranet. Puede contactar con nosotros en el 900 000 000 para aclarar cualquier problema. Gracias..
        /// </summary>
        internal static string OlvidoConCorreo {
            get {
                return ResourceManager.GetString("OlvidoConCorreo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El correo electrónico indicado no figura en nuestra base de datos, póngase en contacto con el teléfono 900 000 000, para poderle proporcionar un usuario y contraseña nuevos..
        /// </summary>
        internal static string OlvidoSinCorreo {
            get {
                return ResourceManager.GetString("OlvidoSinCorreo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Este documento necesita ser revisado por el usuario..
        /// </summary>
        internal static string Revisable {
            get {
                return ResourceManager.GetString("Revisable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Los datos del documento son correctos.
        /// </summary>
        internal static string Revisado {
            get {
                return ResourceManager.GetString("Revisado", resourceCulture);
            }
        }
    }
}