Imports System.Text.RegularExpressions

Namespace Youtube_Viewers.Helpers
    Friend Module RegularExpressions
        Public Viewers As Regex = New Regex("viewCount\"":{\""videoViewCountRenderer\"":{\""viewCount\"":{\""runs\"":\[{\""text\"":\""(.+?)\""}", RegexOptions.Compiled)

        Public Title As Regex = New Regex("\""title\"":{\""runs\"":\[{\""text\"":\""(.+?)\""}", RegexOptions.Compiled)

        Public ViewUrl As Regex = New Regex("videostatsWatchtimeUrl\"":{\""baseUrl\"":\""(.+?)\""}", RegexOptions.Compiled)

        Public Trash As Regex = New Regex("[=/\-+]", RegexOptions.Compiled)
    End Module
End Namespace
