"use strict";(globalThis["webpackChunkfilm_api"]=globalThis["webpackChunkfilm_api"]||[]).push([[866],{9866:(e,l,a)=>{a.r(l),a.d(l,{default:()=>Z});var u=a(9835),t=a(6970),n=a(1569),i=a(499);const d=(0,u._)("div",{class:"text-h3"},"Sign up",-1),s=(0,u.Uk)(" User signed up successfully! "),o=(0,u.Uk)("Sign up"),m=(0,u._)("p",{class:"flex flex-center q-mt-md q-mb-none"},"Have an account?",-1),r=(0,u.Uk)("Sign in"),p={__name:"SignUpPage",setup(e){const l=(0,i.iH)("admin"),a=(0,i.iH)(!0),p=(0,i.iH)(""),c=(0,i.iH)(""),v=(0,i.iH)(""),f=(0,i.iH)(""),w=(0,i.iH)(""),b=(0,i.iH)(!1),g=(0,i.iH)(!1);function _(){const e=l.value;let a="/users/register";const u={username:v.value,password:f.value};"filmstudio"==e&&(a="/filmstudios/register",u.filmStudioCity=c.value,u.filmStudioName=p.value),n.api.post(a,u).then((e=>{g.value=!0,setTimeout((()=>{g.value=!1}),5e3)})).catch((e=>{b.value=!0,w.value=e.response.data.message,setTimeout((()=>b.value=!1),1e4)}))}return(e,n)=>{const i=(0,u.up)("q-card-section"),V=(0,u.up)("q-tab"),W=(0,u.up)("q-tabs"),q=(0,u.up)("q-separator"),y=(0,u.up)("q-input"),k=(0,u.up)("q-icon"),x=(0,u.up)("q-tab-panel"),U=(0,u.up)("q-tab-panels"),h=(0,u.up)("q-banner"),Q=(0,u.up)("q-btn"),Z=(0,u.up)("q-card-actions"),C=(0,u.up)("q-card"),S=(0,u.up)("q-page");return(0,u.wg)(),(0,u.j4)(S,{class:"flex flex-center"},{default:(0,u.w5)((()=>[(0,u.Wm)(C,null,{default:(0,u.w5)((()=>[(0,u.Wm)(i,null,{default:(0,u.w5)((()=>[d])),_:1}),(0,u.Wm)(W,{modelValue:l.value,"onUpdate:modelValue":n[0]||(n[0]=e=>l.value=e),dense:"",class:"text-grey","active-color":"primary","indicator-color":"primary",align:"justify","narrow-indicator":""},{default:(0,u.w5)((()=>[(0,u.Wm)(V,{name:"admin",label:"Administrator"}),(0,u.Wm)(V,{name:"filmstudio",label:"Film Studio"})])),_:1},8,["modelValue"]),(0,u.Wm)(q),(0,u.Wm)(U,{modelValue:l.value,"onUpdate:modelValue":n[11]||(n[11]=e=>l.value=e),animated:""},{default:(0,u.w5)((()=>[(0,u.Wm)(x,{name:"admin",onClick:n[4]||(n[4]=e=>b.value=!1)},{default:(0,u.w5)((()=>[(0,u.Wm)(i,{class:"q-gutter-md",style:{"min-width":"400px"}},{default:(0,u.w5)((()=>[(0,u.Wm)(y,{dense:"",outlined:"",modelValue:v.value,"onUpdate:modelValue":n[1]||(n[1]=e=>v.value=e),label:"Username"},null,8,["modelValue"]),(0,u.Wm)(y,{dense:"",modelValue:f.value,"onUpdate:modelValue":n[3]||(n[3]=e=>f.value=e),outlined:"",label:"Password",type:a.value?"password":"text"},{append:(0,u.w5)((()=>[(0,u.Wm)(k,{name:a.value?"visibility_off":"visibility",class:"cursor-pointer",onClick:n[2]||(n[2]=e=>a.value=!a.value)},null,8,["name"])])),_:1},8,["modelValue","type"])])),_:1})])),_:1}),(0,u.Wm)(x,{name:"filmstudio",onClick:n[10]||(n[10]=e=>b.value=!1)},{default:(0,u.w5)((()=>[(0,u.Wm)(i,{class:"q-gutter-md",style:{"min-width":"400px"}},{default:(0,u.w5)((()=>[(0,u.Wm)(y,{dense:"",outlined:"",modelValue:p.value,"onUpdate:modelValue":n[5]||(n[5]=e=>p.value=e),label:"Studio Name"},null,8,["modelValue"]),(0,u.Wm)(y,{dense:"",outlined:"",modelValue:c.value,"onUpdate:modelValue":n[6]||(n[6]=e=>c.value=e),label:"Studio City"},null,8,["modelValue"]),(0,u.Wm)(y,{dense:"",outlined:"",modelValue:v.value,"onUpdate:modelValue":n[7]||(n[7]=e=>v.value=e),label:"Username"},null,8,["modelValue"]),(0,u.Wm)(y,{dense:"",modelValue:f.value,"onUpdate:modelValue":n[9]||(n[9]=e=>f.value=e),outlined:"",label:"Password",type:a.value?"password":"text"},{append:(0,u.w5)((()=>[(0,u.Wm)(k,{name:a.value?"visibility_off":"visibility",class:"cursor-pointer",onClick:n[8]||(n[8]=e=>a.value=!a.value)},null,8,["name"])])),_:1},8,["modelValue","type"])])),_:1})])),_:1})])),_:1},8,["modelValue"]),b.value?((0,u.wg)(),(0,u.j4)(h,{key:0,class:"text-white bg-red q-ma-md"},{default:(0,u.w5)((()=>[(0,u.Uk)((0,t.zw)(w.value),1)])),_:1})):(0,u.kq)("",!0),g.value?((0,u.wg)(),(0,u.j4)(h,{key:1,class:"text-white bg-green q-ma-md"},{default:(0,u.w5)((()=>[s])),_:1})):(0,u.kq)("",!0),(0,u.Wm)(Z,{class:"flex flex-center"},{default:(0,u.w5)((()=>[(0,u.Wm)(Q,{outline:"",onClick:_},{default:(0,u.w5)((()=>[o])),_:1})])),_:1}),(0,u.Wm)(q),m,(0,u.Wm)(Z,{class:"flex flex-center"},{default:(0,u.w5)((()=>[(0,u.Wm)(Q,{dense:"",class:"bg-primary text-white",to:{name:"signin"}},{default:(0,u.w5)((()=>[r])),_:1})])),_:1})])),_:1})])),_:1})}}};var c=a(9885),v=a(4458),f=a(3190),w=a(7817),b=a(900),g=a(926),_=a(9800),V=a(4106),W=a(6611),q=a(2857),y=a(7128),k=a(1821),x=a(4455),U=a(9984),h=a.n(U);const Q=p,Z=Q;h()(p,"components",{QPage:c.Z,QCard:v.Z,QCardSection:f.Z,QTabs:w.Z,QTab:b.Z,QSeparator:g.Z,QTabPanels:_.Z,QTabPanel:V.Z,QInput:W.Z,QIcon:q.Z,QBanner:y.Z,QCardActions:k.Z,QBtn:x.Z})}}]);