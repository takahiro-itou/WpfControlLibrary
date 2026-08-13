
set  solution=WpfControl
set  config="Debug"


msbuild  -restore  -t:Build     ^
    -p:Configuration=%config%   -p:Platform=x64     ^
    "%solution%.sln"
