Shader "Unlit/logo"
{
    Properties{
        _MainTex("Base (RGB)", 2D) = "white" {} //在属性面板上显示贴图
        _FlashColor("Flash Color", Color) = (1,1,1,1)
        //闪光的颜色
        _Angle("Flash Angle", Range(0, 180)) = 45
        //闪光的角度
        _Width("Flash Width", Range(0, 1)) = 0.2
        //闪光的宽度
        _LoopTime("Loop Time", Float) = 1
        //持续的时间
        _Interval("Time Interval", Float) = 3
        //每一次的间隔
        _BeginTime ("Begin Time", Float) = 2
        //第一次开始的时间
    }
    SubShader
    {
        Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
        //"Queue"表示渲染的顺序，"RenderType"表示渲染的类型
        CGPROGRAM
        #pragma surface surf Lambert alpha exclude_path:prepass noforwardadd
        //surface表示采用哪种渲染类型，surf是定义的方法，与下文相对应
        //alpha是混合，至于后面那个加与不加效果一样，反正我是没弄明白
        #pragma target 3.0
        //在shader中用面板的属性要从新进行一次定义，名字必须一致
        sampler2D _MainTex;
        float4 _FlashColor;
        float _Angle;
        float _Width;
        float _LoopTime;
        float _Interval;
                float _BeginTime;
        //作为surf的输入
        struct Input
        {
            half2 uv_MainTex;
        };
        float inFlash(half2 uv)
        {
            float brightness = 0;//亮度值
            float angleInRad = 0.0174444 * _Angle;//倾斜角
            float tanInverseInRad = 1.0 / tan(angleInRad);//_Angle在0~45°，tanInverseInRad>1;_Angle在45~90°,0<tanInverseInRad<1;
            //_Angle在90~135°，-1<tanInverseInRad<0;_Angle在135~180°,-625<tanInverseInRad<-1,以后的又从头开始循环
                        float currentTime = _Time.y - _BeginTime;//第一次开始的时间
            float totalTime = _Interval + _LoopTime;//从第一次播放到第二次开始播放的间隔
            float currentTurnStartTime = (int)((currentTime / totalTime)) * totalTime;
            float currentTurnTimePassed = currentTime - currentTurnStartTime - _Interval;
            bool onLeft = (tanInverseInRad > 0);
            float xBottomFarLeft = onLeft ? 0.0 : tanInverseInRad;
            float xBottomFarRight = onLeft ? (1.0 + tanInverseInRad) : 1.0;
            float percent = currentTurnTimePassed / _LoopTime;
            float xBottomRightBound = xBottomFarLeft + percent * (xBottomFarRight - xBottomFarLeft);
            float xBottomLeftBound = xBottomRightBound - _Width;
            float xProj = uv.x + uv.y * tanInverseInRad;
            if (xProj > xBottomLeftBound && xProj < xBottomRightBound)
            {
                brightness = 1.0 - abs(2.0 * xProj - (xBottomLeftBound + xBottomRightBound)) / _Width;
            }
            return brightness;
        }
        void surf(Input IN, inout SurfaceOutput o)
        {
            half4 texCol = tex2D(_MainTex, IN.uv_MainTex);//根据uv取得每个像素的颜色
            float brightness = inFlash(IN.uv_MainTex);//传进i.uv等参数，得到亮度值
            o.Albedo = texCol.rgb + _FlashColor.rgb * brightness;//根据每个RGB进行叠加
            o.Alpha = texCol.a;
        }
        ENDCG
    }
    FallBack "Unlit/Transparent"
}