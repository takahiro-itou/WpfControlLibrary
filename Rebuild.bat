
set  solution=WpfControl
set  config="Debug"


msbuild  -restore  -t:Clean     ^
    -p:Configuration=%config%   -p:Platform=x64     ^
    "%solution%.sln"

msbuild  -restore  -t:Rebuild   ^
    -p:Configuration=%config%   -p:Platform=x64     ^
    "%solution%.sln"
