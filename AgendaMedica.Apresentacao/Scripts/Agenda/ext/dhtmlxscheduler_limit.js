/*
This software is allowed to use under GPL or you need to obtain Commercial or Enterise License
to use it in non-GPL project. Please contact sales@dhtmlx.com for details
*/
scheduler.config.limit_start=null;scheduler.config.limit_end=null;scheduler.config.limit_view=!1;scheduler.config.check_limits=!0;scheduler.config.mark_now=!0;scheduler.config.display_marked_timespans=!0;
(function(){var u=null,s="dhx_time_block",F=function(b,a,c){a instanceof Date&&c instanceof Date?(b.start_date=a,b.end_date=c):(b.days=a,b.zones=c);return b},E=function(b,a,c){var d=typeof b=="object"?b:{days:b};d.type=s;d.css="";if(a){if(c)d.sections=c;d=F(d,b,a)}return d};scheduler.blockTime=function(b,a,c){var d=E(b,a,c);return scheduler.addMarkedTimespan(d)};scheduler.unblockTime=function(b,a,c){var a=a||"fullday",d=E(b,a,c);return scheduler.deleteMarkedTimespan(d)};scheduler.attachEvent("onBeforeViewChange",
function(b,a,c,d){d=d||a;c=c||b;return scheduler.config.limit_view&&(d.valueOf()>scheduler.config.limit_end.valueOf()||this.date.add(d,1,c)<=scheduler.config.limit_start.valueOf())?(setTimeout(function(){scheduler.setCurrentView(scheduler._date,c)},1),!1):!0});var x=function(b,a,c){var d=c[a]&&c[a][s]?c[a][s]:c[b]&&c[b][s]?c[b][s]:[];return d},t=function(b){if(!b)return!0;if(!scheduler.config.check_limits)return!0;for(var a=scheduler,c=a._mode,d=scheduler._marked_timespans,e=a.config,h=[],h=b.rec_type?
scheduler.getRecDates(b):[b],g=!0,i=0;i<h.length;i++){var f=h[i];if(g=e.limit_start&&e.limit_end?f.start_date.valueOf()>=e.limit_start.valueOf()&&f.end_date.valueOf()<=e.limit_end.valueOf():!0)for(var j=new Date(f.start_date.valueOf()),p=scheduler.date.add(j,1,"day");j<f.end_date;j=scheduler.date.date_part(p),p=a.date.add(j,1,"day")){var n=+scheduler.date.date_part(new Date(j)),o=j.getDay(),k=[];if(a._props&&a._props[c]){var m=a._props[c],q=d[c];if(q&&q[f[m.map_to]])for(var r=q[f[m.map_to]],v=x(o,
n,r),l=0;l<v.length;l++)k=scheduler._add_timespan_zones(k,v[l].zones)}if(a.matrix&&a.matrix[c]){var s=a.matrix[c],t=d[c];if(t&&t[f[s.y_property]])for(var u=t[f[s.y_property]],A=x(o,n,u),l=0;l<A.length;l++)k=scheduler._add_timespan_zones(k,A[l].zones)}for(var D=d.global,B=x(o,n,D),l=0;l<B.length;l++)k=scheduler._add_timespan_zones(k,B[l].zones);var C=scheduler._get_zone_minutes(j),y=f.end_date>p||f.end_date.getDate()!=j.getDate()?1440:scheduler._get_zone_minutes(f.end_date);if(k)for(l=0;l<k.length;l+=
2){var z=k[l],w=k[l+1];if(z<y&&w>C){if(C<=w&&C>=z){if(w==1440||y<w){g=!1;break}if(f._timed&&a._drag_id&&a._drag_mode=="new-size")f.start_date.setHours(0),f.start_date.setMinutes(w);else{g=!1;break}}if(y>=z&&y<w||C<z&&y>w)if(f._timed&&a._drag_id&&a._drag_mode=="new-size")f.end_date.setHours(0),f.end_date.setMinutes(z);else{g=!1;break}}}}if(!g)a._drag_id=null,a._drag_mode=null,g=a.checkEvent("onLimitViolation")?a.callEvent("onLimitViolation",[f.id,f]):g}return g};scheduler.attachEvent("onMouseDown",
function(b){return!(b=s)});scheduler.attachEvent("onBeforeDrag",function(b){return!b?!0:t(scheduler.getEvent(b))});scheduler.attachEvent("onClick",function(b){return t(scheduler.getEvent(b))});scheduler.attachEvent("onBeforeLightbox",function(b){var a=scheduler.getEvent(b);u=[a.start_date,a.end_date];return t(a)});scheduler.attachEvent("onEventSave",function(b,a){if(a.rec_type){var c=scheduler._lame_clone(a);scheduler._roll_back_dates(c)}return t(a)});scheduler.attachEvent("onEventAdded",function(b){if(!b)return!0;
var a=scheduler.getEvent(b);if(!t(a)&&scheduler.config.limit_start&&scheduler.config.limit_end){if(a.start_date<scheduler.config.limit_start)a.start_date=new Date(scheduler.config.limit_start);if(a.start_date.valueOf()>=scheduler.config.limit_end.valueOf())a.start_date=this.date.add(scheduler.config.limit_end,-1,"day");if(a.end_date<scheduler.config.limit_start)a.end_date=new Date(scheduler.config.limit_start);if(a.end_date.valueOf()>=scheduler.config.limit_end.valueOf())a.end_date=this.date.add(scheduler.config.limit_end,
-1,"day");if(a.start_date.valueOf()>=a.end_date.valueOf())a.end_date=this.date.add(a.start_date,this.config.event_duration||this.config.time_step,"minute");a._timed=this.is_one_day_event(a)}return!0});scheduler.attachEvent("onEventChanged",function(b){if(!b)return!0;var a=scheduler.getEvent(b);if(!t(a)){if(!u)return!1;a.start_date=u[0];a.end_date=u[1];a._timed=this.is_one_day_event(a)}return!0});scheduler.attachEvent("onBeforeEventChanged",function(b){return t(b)});scheduler.attachEvent("onBeforeEventCreated",
function(b){var a=scheduler.getActionData(b).date,c={_timed:!0,start_date:a,end_date:scheduler.date.add(a,scheduler.config.time_step,"minute")};return t(c)});scheduler.attachEvent("onViewChange",function(){scheduler.markNow()});scheduler.attachEvent("onSchedulerResize",function(){window.setTimeout(function(){scheduler.markNow()},1);return!0});scheduler.attachEvent("onTemplatesReady",function(){scheduler._mark_now_timer=window.setInterval(function(){scheduler.markNow()},6E4)});scheduler.markNow=function(b){var a=
"dhx_now_time";this._els[a]||(this._els[a]=[]);var c=scheduler.config.now_date||new Date,d=this.config;scheduler._remove_mark_now();if(!b&&d.mark_now&&c<this._max_date&&c>this._min_date&&c.getHours()>=d.first_hour&&c.getHours()<d.last_hour){var e=this.locate_holder_day(c);this._els[a]=scheduler._append_mark_now(e,c)}};scheduler._append_mark_now=function(b,a){var c="dhx_now_time",d=scheduler._get_zone_minutes(a),e={zones:[d,d+1],css:c,type:c};if(this._table_view){if(this._mode=="month")return e.days=
+scheduler.date.date_part(a),scheduler._render_marked_timespan(e,null,null)}else if(this._props&&this._props[this._mode]){for(var h=this._els.dhx_cal_data[0].childNodes,g=[],i=0;i<h.length-1;i++){var f=b+i;e.days=f;var j=scheduler._render_marked_timespan(e,null,f)[0];g.push(j)}return g}else return e.days=b,scheduler._render_marked_timespan(e,null,b)};scheduler._remove_mark_now=function(){for(var b="dhx_now_time",a=this._els[b],c=0;c<a.length;c++){var d=a[c],e=d.parentNode;e&&e.removeChild(d)}this._els[b]=
[]};scheduler._marked_timespans={global:{}};scheduler._get_zone_minutes=function(b){return b.getHours()*60+b.getMinutes()};scheduler._prepare_timespan_options=function(b){var a=[],c=[];if(b.days=="fullweek")b.days=[0,1,2,3,4,5,6];if(b.days instanceof Array){for(var d=b.days.slice(),e=0;e<d.length;e++){var h=scheduler._lame_clone(b);h.days=d[e];a.push.apply(a,scheduler._prepare_timespan_options(h))}return a}if(!b||!(b.start_date&&b.end_date&&b.end_date>b.start_date||b.days!==void 0&&b.zones))return a;
var g=0,i=1440;if(b.zones=="fullday")b.zones=[g,i];if(b.zones&&b.invert_zones)b.zones=scheduler.invertZones(b.zones);b.id=scheduler.uid();b.css=b.css||"";b.type=b.type||"default";var f=b.sections;if(f)for(var j in f){if(f.hasOwnProperty(j)){var p=f[j];p instanceof Array||(p=[p]);for(e=0;e<p.length;e++){var n=scheduler._lame_copy({},b);n.sections={};n.sections[j]=p[e];c.push(n)}}}else c.push(b);for(var o=0;o<c.length;o++){var k=c[o],m=k.start_date,q=k.end_date;if(m&&q)for(var r=scheduler.date.date_part(new Date(m)),
v=scheduler.date.add(r,1,"day");r<q;){n=scheduler._lame_copy({},k);delete n.start_date;delete n.end_date;n.days=r.valueOf();var l=m>r?scheduler._get_zone_minutes(m):g,s=q>v||q.getDate()!=r.getDate()?i:scheduler._get_zone_minutes(q);n.zones=[l,s];a.push(n);r=v;v=scheduler.date.add(v,1,"day")}else{if(k.days instanceof Date)k.days=scheduler.date.date_part(k.days).valueOf();k.zones=b.zones.slice();a.push(k)}}return a};scheduler._get_dates_by_index=function(b,a,c){for(var d=[],a=a||scheduler._min_date,
c=c||scheduler._max_date,e=a.getDay(),h=b-e>=0?b-e:7-a.getDay()+b,g=scheduler.date.add(a,h,"day");g<c;g=scheduler.date.add(g,1,"week"))d.push(g);return d};scheduler._get_css_classes_by_config=function(b){var a=[];b.type==s&&(a.push(s),b.css&&a.push(s+"_reset"));a.push("dhx_marked_timespan",b.css);return a.join(" ")};scheduler._get_block_by_config=function(b){var a=document.createElement("DIV");if(b.html)typeof b.html=="string"?a.innerHTML=b.html:a.appendChild(b.html);return a};scheduler._render_marked_timespan=
function(b,a,c){var d=[],e=scheduler.config,h=this._min_date,g=this._max_date,i=!1;if(!e.display_marked_timespans)return d;if(!c&&c!==0)if(b.days<7)c=b.days;else{var f=new Date(b.days),i=+f;if(!(+g>=+f&&+h<=+f))return d;var j=f.getDay(),c=scheduler.config.start_on_monday?j==0?6:j-1:j}var p=b.zones,n=scheduler._get_css_classes_by_config(b);if(scheduler._table_view&&scheduler._mode=="month"){var o=[],k=[];if(a)o.push(a),k.push(c);else for(var k=i?[i]:scheduler._get_dates_by_index(c),m=0;m<k.length;m++)o.push(this._scales[k[m]]);
for(m=0;m<o.length;m++)for(var a=o[m],c=k[m],q=0;q<p.length;q+=2){var r=p[m],s=p[m+1];if(s<=r)return[];var l=scheduler._get_block_by_config(b);l.className=n;var t=a.offsetHeight-1,u=a.offsetWidth-1,x=Math.floor((this._correct_shift(c,1)-h.valueOf())/(864E5*this._cols.length)),A=this.locate_holder_day(c,!1)%this._cols.length,D=this._colsS[A],B=this._colsS.heights[x]+(this._colsS.height?this.xy.month_scale_height+2:2)-1;l.style.top=B+"px";l.style.lineHeight=l.style.height=t+"px";l.style.left=D+Math.round(r/
1440*u)+"px";l.style.width=Math.round((s-r)/1440*u)+"px";a.appendChild(l);d.push(l)}}else{a=a?a:scheduler.locate_holder(c);for(m=0;m<p.length;m+=2){r=Math.max(p[m],e.first_hour*60);s=Math.min(p[m+1],e.last_hour*60);if(s<=r)return[];l=scheduler._get_block_by_config(b);l.className=n;l.style.top=Math.round((r*6E4-this.config.first_hour*36E5)*this.config.hour_size_px/36E5)%(this.config.hour_size_px*24)+"px";l.style.lineHeight=l.style.height=Math.max(Math.round((s-r-1)*6E4*this.config.hour_size_px/36E5)%
(this.config.hour_size_px*24),1)+"px";a.appendChild(l);d.push(l)}}return d};scheduler.markTimespan=function(b){var a=scheduler._prepare_timespan_options(b);if(a.length){for(var c=[],d=0;d<a.length;d++){var e=a[d],h=scheduler._render_marked_timespan(e,null,null);h.length&&c.push.apply(c,h)}return c}};scheduler.unmarkTimespan=function(b){if(b)for(var a=0;a<b.length;a++){var c=b[a];c.parentNode.removeChild(c)}};scheduler._marked_timespans_ids={};scheduler.addMarkedTimespan=function(b){var a=scheduler._prepare_timespan_options(b),
c="global";if(a.length){var d=a[0].id,e=scheduler._marked_timespans,h=scheduler._marked_timespans_ids;h[d]||(h[d]=[]);for(var g=0;g<a.length;g++){var i=a[g],f=i.days,j=i.zones,p=i.css,n=i.sections,o=i.type;if(n)for(var k in n){if(n.hasOwnProperty(k)){e[k]||(e[k]={});var m=n[k],q=e[k];q[m]||(q[m]={});q[m][f]||(q[m][f]={});q[m][f][o]||(q[m][f][o]=[]);var r=q[m][f][o];i._array=r;r.push(i);h[d].push(i)}}else e[c][f]||(e[c][f]={}),e[c][f][o]||(e[c][f][o]=[]),r=e[c][f][o],i._array=r,r.push(i),h[d].push(i)}return d}};
scheduler._add_timespan_zones=function(b,a){var c=b.slice(),a=a.slice();if(!c.length)return a;for(var d=0;d<c.length;d+=2)for(var e=c[d],h=c[d+1],g=d+2==c.length,i=0;i<a.length;i+=2){var f=a[i],j=a[i+1];if(j>h&&f<=h||f<e&&j>=e)c[d]=Math.min(e,f),c[d+1]=Math.max(h,j),d-=2;else{if(!g)continue;var p=e>f?0:2;c.splice(d+p,0,f,j)}a.splice(i--,2);break}return c};scheduler._subtract_timespan_zones=function(b,a){for(var c=b.slice(),d=0;d<c.length;d+=2)for(var e=c[d],h=c[d+1],g=0;g<a.length;g+=2){var i=a[g],
f=a[g+1];if(f>e&&i<h){var j=!1;e>=i&&h<=f&&c.splice(d,2);e<i&&(c.splice(d,2,e,i),j=!0);h>f&&c.splice(j?d+2:d,j?0:2,f,h);d-=2;break}}return c};scheduler.invertZones=function(b){return scheduler._subtract_timespan_zones([0,1440],b.slice())};scheduler._delete_marked_timespan_by_id=function(b){var a=scheduler._marked_timespans_ids[b];if(a)for(var c=0;c<a.length;c++)for(var d=a[c],e=d._array,h=0;h<e.length;h++)if(e[h]==d){e.splice(h,1);break}};scheduler._delete_marked_timespan_by_config=function(b){var a=
scheduler._marked_timespans,c=b.sections,d=b.days,e=b.type||"default",h=[];if(c)for(var g in c){if(c.hasOwnProperty(g)&&a[g]){var i=c[g];a[g][i]&&a[g][i][d]&&a[g][i][d][e]&&(h=a[g][i][d][e])}}else a.global[d]&&a.global[d][e]&&(h=a.global[d][e]);for(var f=0;f<h.length;f++){var j=h[f],p=scheduler._subtract_timespan_zones(j.zones,b.zones);if(p.length)j.zones=p;else{h.splice(f,1);f--;for(var n=scheduler._marked_timespans_ids[j.id],o=0;o<n.length;o++)if(n[o]==j){n.splice(o,1);break}}}};scheduler.deleteMarkedTimespan=
function(b){if(!arguments.length)scheduler._marked_timespans={global:{}};if(typeof b!="object")scheduler._delete_marked_timespan_by_id(b);else for(var a=scheduler._prepare_timespan_options(b),c=0;c<a.length;c++){var d=a[c];scheduler._delete_marked_timespan_by_config(a[c])}};scheduler._get_types_to_render=function(b,a){var c=b?b:{},d;for(d in a||{})a.hasOwnProperty(d)&&(c[d]=a[d]);return c};scheduler._get_configs_to_render=function(b){var a=[],c;for(c in b)b.hasOwnProperty(c)&&a.push.apply(a,b[c]);
return a};scheduler.attachEvent("onScaleAdd",function(b,a){if(!(scheduler._table_view&&scheduler._mode!="month")){var c=a.getDay(),d=a.valueOf(),e=this._mode,h=scheduler._marked_timespans,g=[];if(this._props&&this._props[e]){var i=this._props[e],f=i.options,j=(i.position||0)+Math.floor((this._correct_shift(a.valueOf(),1)-this._min_date.valueOf())/864E5),p=f[j],a=scheduler.date.date_part(new Date(this._date)),c=a.getDay(),d=a.valueOf();if(h[e]&&h[e][p.key]){var n=h[e][p.key],o=scheduler._get_types_to_render(n[c],
n[d]);g.push.apply(g,scheduler._get_configs_to_render(o))}}var k=h.global,m=k[d]||k[c];g.push.apply(g,scheduler._get_configs_to_render(m));for(var q=0;q<g.length;q++)scheduler._render_marked_timespan(g[q],b,a)}})})();
