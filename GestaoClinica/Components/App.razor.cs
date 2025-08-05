using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;

namespace GestaoClinica
{
    public partial class App
    {
        [Inject]
        private IComponentRenderMode? InteractiveServerRenderMode { get; set; }
    }
}