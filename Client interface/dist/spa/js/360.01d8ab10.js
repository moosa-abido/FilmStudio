"use strict";(globalThis["webpackChunkfilm_api"]=globalThis["webpackChunkfilm_api"]||[]).push([[360],{3682:(e,t,s)=>{s.d(t,{t:()=>l});var a=s(2502);const l=(0,a.Q_)("auth",{state:()=>({user:null}),getters:{loggedInUser(){return null==this.user&&(this.user=JSON.parse(localStorage.getItem("user"))),this.user}},actions:{setUser(e){this.user=e,localStorage.setItem("user",JSON.stringify(e))},resetUser(){this.user=null,localStorage.removeItem("user")}}})},7360:(e,t,s)=>{s.r(t),s.d(t,{default:()=>W});var a=s(9835),l=s(6970),n=s(3682),r=s(499);const o={class:"GL__toolbar-link q-ml-xs q-gutter-md text-body2 text-weight-bold row items-center no-wrap"},u=(0,a._)("span",{class:"text-bold text-h6"},"Admin page",-1),i=(0,a.Uk)(" Films "),m=(0,a.Uk)(" Film studios "),c={class:"q-pl-sm q-gutter-sm row items-center no-wrap"},d=(0,a.Uk)(" Sign out "),p={__name:"AdminLayout",setup(e){const t=(0,n.t)(),s=(0,r.iH)(t.loggedInUser.username);function p(){t.resetUser()}return(e,t)=>{const n=(0,a.up)("q-icon"),r=(0,a.up)("q-btn"),g=(0,a.up)("q-space"),w=(0,a.up)("q-toolbar"),h=(0,a.up)("q-header"),_=(0,a.up)("router-view"),f=(0,a.up)("q-page-container"),b=(0,a.up)("q-layout");return(0,a.wg)(),(0,a.j4)(b,{class:"bg-grey-1"},{default:(0,a.w5)((()=>[(0,a.Wm)(h,{elevated:"",class:"text-white",style:{background:"#24292e"},"height-hint":"61.59"},{default:(0,a.w5)((()=>[(0,a.Wm)(w,{class:"q-py-sm q-px-md"},{default:(0,a.w5)((()=>[(0,a.Wm)(n,{name:"img:logo.jpg",size:"xl"}),(0,a._)("div",o,[u,(0,a.Wm)(r,{outline:"",to:{name:"films"},class:"text-white"},{default:(0,a.w5)((()=>[i])),_:1}),(0,a.Wm)(r,{outline:"",to:{name:"filmstudios"},class:"text-white"},{default:(0,a.w5)((()=>[m])),_:1})]),(0,a.Wm)(g),(0,a._)("div",c,[(0,a._)("span",null,"User: "+(0,l.zw)(s.value),1),(0,a.Wm)(r,{dense:"",flat:"","no-wrap":"",to:{name:"signin"},onClick:p},{default:(0,a.w5)((()=>[d])),_:1})])])),_:1})])),_:1}),(0,a.Wm)(f,null,{default:(0,a.w5)((()=>[(0,a.Wm)(_)])),_:1})])),_:1})}}};var g=s(7605),w=s(6602),h=s(1663),_=s(2857),f=s(4455),b=s(136),q=s(2133),k=s(490),x=s(8149),Q=s(9984),v=s.n(Q);const U=p,W=U;v()(p,"components",{QLayout:g.Z,QHeader:w.Z,QToolbar:h.Z,QIcon:_.Z,QBtn:f.Z,QSpace:b.Z,QPageContainer:q.Z,QItem:k.Z,QField:x.Z})}}]);