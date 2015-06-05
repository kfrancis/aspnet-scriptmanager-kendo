# microsoft-scriptmanager-kendo

Quick ScriptManager libary which adds a named script reference definition for easy use (rather than specifying the version number in every single script reference).

To use:

1. Simply install Kendo (hopefully from NuGet) so the scripts are placed in their default location
2. Install this NuGet (select the version that matches your kendo version)
3. Use (see below)

Example 1: Using the non-SSL CDN

```ASP
<asp:ScriptManager runat="server" EnablePartialRendering="true" EnableCdn="true" EnableCdnFallback="true">
    <Scripts>
        <asp:ScriptReference Name="kendo-web" />
    </Scripts>
</asp:ScriptManager>
```

Example 2: Using the SSL CDN

```ASP
<asp:ScriptManager runat="server" EnablePartialRendering="true" EnableCdn="true" EnableCdnFallback="true">
    <Scripts>
        <asp:ScriptReference Name="kendo-web-secure" />
    </Scripts>
</asp:ScriptManager>
```

There are two named script definitions because there's no single CDN url for both SSL and non-SSL at the moment.