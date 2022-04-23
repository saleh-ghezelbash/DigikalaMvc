

function checkclickininput()
{
    var $win=$(window);
    var $input=$('.js-input_search');
    var $result=$('.js-search_result');
    var $cover=$('.js-cover');

    $win.on('click',function(event)
    {
        if(
            $input.is(event.target)
            ||
            $result.has(event.target).length == 1
        )
        {
                $result.addClass('is-active');
                $cover.addClass('is-active');
                $('.js-input_search').addClass('is-active');
        }
        else
        {
            $result.removeClass('is-active');
            $cover.removeClass('is-active');
            $('.js-input_search').removeClass('is-active');
            $(".js-mobile-input_search").parent().parent().removeClass("is-active")
           
        }
    });
};

checkclickininput();

function Open_Dropdown_User()
{
    var $win=$(window);
    var $btn_user=$('.js-header_btn-user');
    var $dropdown=$('.js-header_user-dropdown');
    var $notifi=$('.js-header_btn-user_has-noticcation');
    $win.on('click',function(event)
    {
        if(
            $btn_user.is(event.target)
        )
        {
            if($dropdown.hasClass('is-active'))
            {
                $dropdown.removeClass('is-active');
                $notifi.removeClass('not-active');
                $btn_user.removeClass('is-active');
            }
            else{
                $dropdown.addClass('is-active');
                $notifi.addClass('not-active');
                $btn_user.addClass('is-active');
            }
        }
        else
        {
            $dropdown.removeClass('is-active');
            $notifi.removeClass('not-active');
            $btn_user.removeClass('is-activetest.com/chat');
           
        }
    });
};

 Open_Dropdown_User();

 function Open_Dropdown_basket()
 {
     var $win=$(window);
     var $btn_user=$('.js-header_btn-cart');
     var $dropdown=$('.js-header_basket-dropdown');
     $win.on('click',function(event)
     {
         if(
             $btn_user.is(event.target)
         )
         {
             if($dropdown.hasClass('is-active'))
             {
                 $dropdown.removeClass('is-active');
             }
             else{
                 $dropdown.addClass('is-active');
             }
         }
         else
         {
             $dropdown.removeClass('is-active');
            
         }
     });
 };

 Open_Dropdown_basket();

 function menuhover()
 {
     var $li=$(".js-topmenu_list-li");
     var $li_hover=$(".js-topmenu_list-hover");

     $li.hover(function(){
       

        var $parent=$(this).parent().parent().parent();
        $li_hover.css('width',$(this).width());
        $li_hover.css('right',$parent.width()-($(this).offset().left + $(this).width()) + $parent.offset().left);
        $li_hover.css('transform','scaleX(1)');
      
        $('.js-header_user-dropdown').removeClass('is-active');
        $('.js-search_result').removeClass('is-active');
        $(".js-header_basket-dropdown").removeClass('is-active');
        $('.js-input_search').removeClass('is-active');
       
        setTimeout(function() {
           
            //  $(this).addClass('show-menu');
        },200)
     },function()
     {
        $li_hover.css('transform','scaleX(0)');
  

        setTimeout(function() {
            $('.js-cover').removeClass('is-active');
            $(this).removeClass('show-menu');
        },200)
     });

 };


 function mainmenu(){
    $('.js-topmenu_list-a').hover(function(){
        $('.js-topmenu_list-a').removeClass('is-hoverd');
        $(this).addClass('is-hoverd');
        $('.js-topmenu_sublist').removeClass('is-active');
        $('.js-topmenu_sublist[data-id='+$(this).data('id')+']').addClass('is-active');
    });
   var menutimeer;
    $('.js-topmenu_list-li-has-sublist').hover(function(){
        var that=$(this)
        menutimeer=  setTimeout(function() {
            that.children('.js-topmenu_list-main_menu-container').addClass('is-active')
            $('.js-cover').addClass('is-active');
        }, 200);
      
    },function()
    {
        
       clearTimeout(menutimeer);
          
           $('.js-cover').removeClass('is-active');
           $(this).children('.js-topmenu_list-main_menu-container').removeClass('is-active')
       
    })
 }

 mainmenu()
 menuhover();

 function main_slideshow()
 {
     try{
     var slide=document.getElementsByClassName('js-slide');
     var dots=document.getElementsByClassName('js-slider_dots-span');
     var next=document.querySelector('.js-slider_next');
     var prev=document.querySelector('.js-slider_prev');
        var n=0;
        var i;

        function removeClass()
        {
            for(i=0;i<slide.length;i++)
            {
                slide[i].classList.remove('fadein');
                 dots[i].classList.remove('is-active');

            }
        }

     next.addEventListener('click',function()
     {
         n++;
         if(n>slide.length-1)
         {
             n=0;
             
         }
         removeClass();
        slide[n].classList.add('fadein');
        dots[n].classList.add('is-active');
        clearInterval(interval);
     })

     prev.addEventListener('click',function()
     {
         n--;
         if(n<0)
         {
             n=slide.length-1;
             
         }
         removeClass();
        slide[n].classList.add('fadein');
        dots[n].classList.add('is-active');
        clearInterval(interval);
     })

     $('.js-slider_dots-span').click(function(){
         var index=$(this).index();
         removeClass();
        slide[index].classList.add('fadein');
        dots[index].classList.add('is-active');
        n=index;
        clearInterval(interval);
     })

     var interval=setInterval(function()
     {
        n++;
        if(n>slide.length-1)
        {
            n=0;
            
        }
        removeClass();
       slide[n].classList.add('fadein');
       dots[n].classList.add('is-active');
     },5000)
    }
    catch (error){}

 };



 function discount_timer()
 {
     var delta;
     var day;
     var hour;
     var minutes;
     var seconds;
     $('.js-counter').each(function(index){
         var x=$(this);
         var container=document.getElementsByClassName('js-discount_container').item(index);
         var price=container.querySelector('.js-discount_price');
         var price_finish=container.querySelector('.js-discount_price-finish');
         var counter=container.querySelector('.js-discount_counter');
         var counter_finish=container.querySelector('.js-discount_counter-finish');

         var now_date=new Date(x.data('nowdate'));
         var discount_date=new Date(x.data('discountdate'));
         setInterval(function(){

            if(discount_date>now_date)
            {
                now_date.setSeconds(now_date.getSeconds() + 1);
            delta=(discount_date-now_date) / 1000;
            day=Math.floor(delta /86400);
            delta-= day * 86400;

            hour=Math.floor(delta / 3600);
            delta-=hour*3600;

            minutes=Math.floor(delta / 60);
            delta-= minutes * 60;
            seconds=Math.floor(delta);
                x.html('<span>'+hour+'</span>:<span>'+minutes+'</span>:<span>'+seconds+'</span>');
                x.persiaNumber();
            
            }
            else
            {
                price.classList.add('not-active');
                counter.classList.add('not-active');

                price_finish.classList.add('is-active');
                counter_finish.classList.add('is-active');
            }
         },1000);
        
     });

     $('.js-product_box-counter').each(function(index){
        var x=$(this);
       

        var now_date=new Date(x.data('nowdate'));
        var discount_date=new Date(x.data('discountdate'));
        setInterval(function(){

           if(discount_date>now_date)
           {
               now_date.setSeconds(now_date.getSeconds() + 1);
           delta=(discount_date-now_date) / 1000;
           day=Math.floor(delta /86400);
           delta-= day * 86400;

           hour=Math.floor(delta / 3600);
           delta-=hour*3600;

           minutes=Math.floor(delta / 60);
           delta-= minutes * 60;
           seconds=Math.floor(delta);
               x.html('<span>'+('0' + hour).slice(-2)+'</span>:<span>'+('0'+minutes).slice(-2)+'</span>:<span>'+('0'+seconds).slice(-2)+'</span>');
               x.persiaNumber();
           
           }
          
        },1000);
       
    });
 }

 discount_timer();


 function discount_slideshow()
 {
     try{
     var slide=document.getElementsByClassName('js-discount_container');
     var dots=document.getElementsByClassName('js-discount_aside-a');
     var next=document.querySelector('.js-discount_btn-next');
     var prev=document.querySelector('.js-discount_btn-prev');
        var n=0;
        var i;

        function removeClass()
        {
            for(i=0;i<slide.length;i++)
            {
                slide[i].classList.remove('is-active');
                 dots[i].classList.remove('is-active');

            }
        }

     next.addEventListener('click',function()
     {
         n++;
         if(n>slide.length-1)
         {
             n=0;
             
         }
         removeClass();
        slide[n].classList.add('is-active');
        dots[n].classList.add('is-active');
        discount_list_slider(n);
        clearInterval(interval);
     })

     prev.addEventListener('click',function()
     {
         n--;
         if(n<0)
         {
             n=slide.length-1;
             
         }
         removeClass();
        slide[n].classList.add('is-active');
        dots[n].classList.add('is-active');
        clearInterval(interval);
        discount_list_slider(n);
     })

     $('.js-discount_aside-li').click(function(){
         var index=$(this).index();
         removeClass();
        slide[index].classList.add('is-active');
        dots[index].classList.add('is-active');
        n=index;
        clearInterval(interval);
        interval=setInterval(nextslide,4000);
        discount_list_slider(n);

     })

     interval=setInterval(nextslide,4000)

     function nextslide()
     {
        n++;
        if(n>slide.length-1)
        {
            n=0;
            
        }
        removeClass();
       slide[n].classList.add('is-active');
       dots[n].classList.add('is-active');
       discount_list_slider(n);
     }
    }catch (error){}

 };

 discount_slideshow();

 function discount_list_slider(n)
 {
    var ul=$('.js-discount_aside-ul');
    var container=$('.js-discount_aside-container');
    var li=document.getElementsByClassName('js-discount_aside-li');
    var array=[];
    var sum_width=0;
    var max_right=container.width()-ul.width();

    $('.js-discount_aside-li').each(function(){
        array.push($(this).width() + 20);
    });
    for(i=0;i<=n;i++)
    {
        sum_width+=array[i];
    }
    var right=container.width()-sum_width;
    var half_width=(container.width() /2)-((li[n].offsetWidth +20) /2);
    if((right-(container.width() /2))>0)
    {
        ul.css('right',0);
    }
    else
    {
        if((right-half_width)<max_right)
        {
            ul.css('right',max_right);   
        }
        else
        {
        ul.css('right',right -half_width);
        }
    }
    
    
 }

 function swiper(){
     var window_width=$(window).width();
    $('.js-swiper_content').each(function(){
        var content=$(this);
        var slide=content.find('.js-swiper_slide');
        var swiper_box=content.find('.js-swiper_box');

        var lg=content.data('count-lg');
        var xl=content.data('count-xl');
        var xxl=content.data('count-xxl');

        var next=content.find('.js-swiper_btn-next');
        var prev=content.find('.js-swiper_btn-prev');

        var slider_width=0;
        var active_item=0;
        var transform=0;
        var max_transform=0;
        var is_max=0;
        var lg_size=1368;
        var xl_size=1680;
        change_width()
        $(window).on('resize',function()
        {
            window_width=$(window).width();
            change_width();
            change_transform();
        })

        function change_transform()
        {
            transform=0
            for(i=0;i<active_item;i++)
            {
                transform+=slider_width;
            }
            if(window_width<lg_size)
            {
                max_transform=slider_width * (slide.length - lg);
                
                if(slide.length>lg && transform>0)
                {
                    if(transform<max_transform && is_max==0){
                        swiper_box.css('transform','translateX('+transform+'px)');
                    }
                    else
                    {
                        swiper_box.css('transform','translateX('+max_transform+'px)');
                        active_item=slide.length-Math.ceil(lg);
                        is_max=1;
                    }
                }
                else{
                    swiper_box.css('transform','translateX('+0+'px)');
                    active_item=0
                }
                
            }
            else if(window_width<xl_size)
            {
                max_transform=slider_width * (slide.length - xl);
                
                if(slide.length>lg && transform>0)
                {
                    if(transform<max_transform && is_max==0){
                        swiper_box.css('transform','translateX('+transform+'px)');
                    }
                    else
                    {
                        swiper_box.css('transform','translateX('+max_transform+'px)');
                        active_item=slide.length-Math.ceil(xl);
                        is_max=1;
                    }
                }
                else{
                    swiper_box.css('transform','translateX('+0+'px)');
                    active_item=0
                }
            }
            else{
                max_transform=slider_width * (slide.length - xxl);
                
                if(slide.length>lg && transform>0)
                {
                    if(transform<max_transform && is_max==0){
                        swiper_box.css('transform','translateX('+transform+'px)');
                    }
                    else
                    {
                        swiper_box.css('transform','translateX('+max_transform+'px)');
                        active_item=slide.length-Math.ceil(xxl);
                        is_max=1;
                    }
                }
                else{
                    swiper_box.css('transform','translateX('+0+'px)');
                    active_item=0
                }
            }
        }

        next.on('click',function(){
            if(window_width<lg_size)
            {
                 active_item+=(Math.floor(lg-1));
                 change_transform();
                 check_disable(lg)
            }
             else if(window_width<xl_size)
            {
                active_item+=(Math.floor(xl-1));
                change_transform();
                check_disable(xl)
            }
            else
            {
                active_item+=(Math.floor(xxl-1));
                change_transform();
                check_disable(xxl)
            }
        });

        prev.on('click',function(){
            if(window_width<lg_size)
            {
                 active_item-=(Math.floor(lg-1));
                 is_max=0;
                 change_transform();
                  check_disable(lg)
            }
             else if(window_width<xl_size)
            {
                active_item-=(Math.floor(xl-1));
                is_max=0;
                change_transform();
                 check_disable(xl)
            }
            else
            {
                active_item-=(Math.floor(xxl-1));
                is_max=0;
                change_transform();
                 check_disable(xxl)
            }
        });

        function check_disable(size)
        {
            if(slide.length<size)
            {
                next.addClass('disable');
                prev.addClass('disable');
            }
            else if(transform<=0)
            {
                next.removeClass('disable');
                prev.addClass('disable');
            }
            else if(is_max==1)
            {
                next.addClass('disable');
                prev.removeClass('disable');
            }
            else{
                next.removeClass('disable');
                prev.removeClass('disable');
            }
        }

        function change_width()
        {
            if(window_width<lg_size)
            {
                slider_width=content.width()/lg;
                slide.css('width',slider_width);
                check_disable(lg)
                
            }
            else if(window_width<xl_size)
            {
                slider_width=content.width()/xl;
                slide.css('width',slider_width);
                check_disable(xl)
                
            }
            else{
                slider_width=content.width()/xxl;
                slide.css('width',slider_width);
                check_disable(xxl)
            }
        }
        
    });
 }



 function single_swiper()
 {
    var box=$('.js-single_swiper-box');
    var item=box.find('.js-single_swiper-slide');
    var headline=$('.js-single_swiper-headline');
    var box_width=box.width();
    var active_item=1;
    var transform=0;
    var second=0;

    item.css('width',Math.ceil(box_width));

    $(window).on('resize',function(){
        box_width=box.width();
        item.css('width',Math.ceil(box_width));
        clearInterval(interval);
        calc_transform();

    });

    var interval=setInterval(swiper_slideshow,100);

    function swiper_slideshow()
    {
        second+=10;
        if(second>=500)
        {
            headline.removeClass('is-active');
            if(active_item>=item.length)
            {
                active_item=1
            }
            else{
            active_item++;
            }
            second=0;
            setTimeout(calc_transform,50);
        clearInterval(interval);
            
        }
    }

    function calc_transform()
    {
        transform =0;

        for(i=1;i<active_item;i++)
        {
            transform+=box_width;
        }

        box.css('transform','translateX('+transform+'px)')
        headline.addClass('is-active');
        interval=setInterval(swiper_slideshow,100);


    }

    box.hover(function()
    {
        headline.addClass('pause');
        clearInterval(interval);
    },function(){
        headline.removeClass('pause');
        interval=setInterval(swiper_slideshow,100);
    })

 };

 single_swiper();

 function jump_top()
 {
    $('.js-footer_jump-top_container').on('click',function(){
        $('html,body').animate({scrollTop:0},500);
    })
 };

 jump_top();

 function footer()
 {
     var content=$('.js-footer_seo-readmore');
    $('.js-footer_btn-readmore').on('click',function(e){
        e.preventDefault();
        if(content.is(":visible")){
            content.hide();
            $(this).text('مشاهده بیشتر')
        }
        else{
            content.show();
            $(this).text('بستن')
        }
    });
 };
 footer();

 function category_card()
 {
     var list=document.getElementsByClassName('js-category_card_item');
     var toparray=new Array();
     var hieghtarray=[0,0,0];
     var width=$(document).width();
     if(width > 720){
        card();
     }
     
     $(window).on('resize',function(){
        width=$(document).width();
        hieghtarray=[0,0,0];
        toparray=[]

        if(width > 720){
            card();
         }
       
    })
    function card(){
     $('.js-category_card_item').each(function(index){
        var container=$(this);
        change_position();
      

        function change_position(){
            
            var max_height=0;
            var width=container.width();
            var andis=index+1;
            var row=Math.ceil(andis / 3);
            var colmun=index - ((row-1) * 3);
            var top_index=andis > 3 ? andis - 3:0;
            var top=0;
            container.css('right',width * colmun + (colmun*20));
            hieghtarray[colmun]+=container.height();
            if(top_index==0)
            {
                top=0;
            }else{
                top=(toparray[top_index-1] + list[top_index-1].clientHeight )+ 20;
            }
            toparray.push(top);

            container.css('top',top);

            if(index== list.length-1)
            {
                for(i=0;i<=2;i++)
                {
                    hieghtarray[i]>max_height ? max_height=hieghtarray[i] : max_height=max_height;
                }
                $('.js-category_card').css('height',max_height + (row * 25))
            }
        }

     });
    }
 }

 category_card()

 function search_clear()
 {
    var input_search=$('.js-box_search-input');
    input_search.each(function()
    {
        var button_clear=$(this).siblings('.js-box_search-input_clear').first();
        var input=$(this);
        input.on('keyup',function(){
            if($(this).val().length > 0)
            {
                button_clear.css('display','block');
            }
            else{
                button_clear.css('display','none');
            }
        });

        button_clear.on('click',function(){
            input.val('');
            button_clear.css('display','none');
        });

        if($(this).val().length>0)
        {
            button_clear.css('display','block');
        }
    })
 }

 search_clear();

 function search_filter()
 {
    var filter_input=$('.js-filter_input');
    filter_input.on('keyup',function()
    {
        var that=$(this);
        var content=that.closest('.js-box_filter');
        if(that.val().length > 0)
        {
            $('.js-filter_label',content).each(function(){
                var pattern= new RegExp(that.val(),'i');
                
                if(pattern.test($(this).data('fa')) || pattern.test($(this).data('en')))
                {
                   $(this).closest('li').show();
                }
                else{
                    $(this).closest('li').hide();
                }
            })
        }
        else
        {
            $('li',content).show();
        }
    });
 };

 search_filter();



 function nouislider()
 {
     try{
    var html5Slider = document.querySelector('.c-range_slider');
    var input_from=document.querySelector('.js-slider_range-from');
    var input_to=document.querySelector('.js-slider_range-to');
    var min=parseInt(input_from.dataset.range)
    var max=parseInt(input_to.dataset.range)


    noUiSlider.create(html5Slider, {
        start: [min, max],
        connect: true,
        direction:'rtl',
        range: {
            'min': min,
            'max': max
        }
    });


    html5Slider.noUiSlider.on('update', function (values, handle) {

        var value = values[handle];
       
        if (handle) {
            input_to.value = currency(ToFadigit( Math.round(value)));
        } else {
            input_from.value =ToFadigit(currency( Math.round(value)));
        }

        if(parseInt(values[0]) !==min || parseInt(values[1]) !==max)
        {
            $('.js-filter_price-btn').removeClass('disabled');
        }
        else{
            $('.js-filter_price-btn').addClass('disabled');
        }


    });
}
catch (error){}
    
 };

 nouislider();

 function currency(val){
   
    var str=val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
   
    return str;

 };
 function ToFadigit(val){
    var en_number = ['0','1','2','3','4','5','6','7','8','9'];
    var fa_number = ['۰','۱','۲','۳','۴','۵','۶','۷','۸','۹'];
    for(i=0;i<=9;i++)
    {
        var regex=new RegExp(en_number[i],'g');
        val=val.toString().replace(regex,fa_number[i]);
    }
    return val;
 }

 function search_page(){
    change_list_type();
    change_position_right_panel();

    var win_width = $(document).width();
    var is_run = 0;

    if(win_width > 720)
    {
        is_run=1
    }
    $(window).on("resize",function(){
        win_width = $(document).width();
        if(win_width > 720)
            {
                is_run=1
            }
            else{
                is_run=0;
            }
    })

    
    
    
   
    function change_list_type(){
        var  btn_list_type=$('.js-listing-type');
        var container=$('.js-search_page-list');
         container=$('.js-search_page-list');

         btn_list_type.on('click',function(){
             if($(this).hasClass('is-active')){
                 return;
             }

             $(".js-listing-type").removeClass('is-active');
             $(this).addClass('is-active');

             if(container.hasClass('is-list'))
             {
                container.removeClass('is-list');
             }
             else{
                container.addClass('is-list');

             }
         })



    }
    var right=$('.js-search_page-right_content');
    var scroll_value=0;
    var position=0;
    var max_transform=0;
    var container_height=0;
    var right_height;
    var right_width=0;
    var window_height;
    var transform_type=0;
    var transform=0;
    function change_position_right_panel(){
        var container=$('.js-search_page-left');
        $(window).scroll(function(){
            if(is_run == 1){
            scroll_value=$(document).scrollTop();
            container_height=container.height();
            right_height=right.height();
            max_transform=(container_height-right_height);
            window_height=$(window).height();
           
            if(scroll_value>position)
            {
                if(scroll_value < $('.js-header').height())
                return ;
                scrolldown();
             
            }
            else{
                 scrollup();
                

            }

            position=scroll_value;
        }
        });

        function scrolldown(){
           if((right.offset().top + right_height -115)>container_height)
           {
               right.removeAttr('style');
               right.css({position:"relative","transform":'translateY('+max_transform+'px)'});
               transform=max_transform;
               transform_type=6;
               console.log(6)
           }
           else if(transform_type==3)
           {
                transform=(scroll_value - 115);
                right.removeAttr('style');
                right.css({position:"relative","transform":"translateY("+transform+"px)"});
                transform_type=2;
                console.log(2)
           }
           else if((scroll_value - 115+window_height) >(right_height+transform))
           {
               if(right_height>window_height){
                    right.removeAttr('style');
                    right_width=$('.js-search_page-right').width();
                    right.css({position:"fixed",width:right_width,bottom:"15px"});
                    transform_type=1;
                    console.log(1)
                }
                else{
                    right.removeAttr('style');
                    right_width=$('.js-search_page-right').width();
                    right.css({position:"fixed",width:right_width,top:"15px"});
                    console.log(20)
                }
           }

         
        }

        function scrollup()
        {
            if(transform_type==5)
            {
                max_transform=(container_height-right.height());
                right.css({position:"relative","transform":'translateY('+max_transform+'px)'});
                transform=max_transform;
                transform_type=6;
            }

            if(scroll_value<115)
            {
                right.removeAttr('style')
                right.css({position:"relative","transform":'translateY(0px)'});
            }
            else{
                if(transform_type==1)
                {
                    right.removeAttr('style');
                    transform=(scroll_value - 115+window_height-right_height);
                    right.css({position:"relative","transform":"translateY("+transform+"px)"});
                    transform_type=4;
                }
                else if((scroll_value-115)<transform){
                    right.removeAttr('style');
                    right_width=$('.js-search_page-right').width();
                    right.css({position:"fixed",width:right_width,top:"15px"});
                    transform_type=3;
                }
            }

        }
        function tooggle_box()
        {  
           $('.js-box_toggleable').each(function(){
               var that = $(this);
               var content = $('.js-box_filter');
               if(that.hasClass('is-hidden'))
               {
                   that.next(content).slideUp();
               }
               that.on('click',function(){
                   
                   if(that.hasClass('is-hidden'))
                   {
                       that.removeClass('is-hidden');
                       that.next(content).slideDown();
                       if(transform_type==6)
                       {
                           transform_type=5;
                           right.css("transition","transform .1s ease-in-out");
                           setTimeout(scrollup,450)
                       }
                       else{
                        scrollup()
                       }
                       
       
                   }else{
                       that.addClass('is-hidden');
                       that.next(content).slideUp();
                       $(document).scrollTop(scroll_value +1)
       
                   }
               });
       })
        };
       
        tooggle_box();

        
        function footer() {
            var content = $('.js-cateogry_desc');
            $('.js-cateogry_desc-btn').on('click', function (e) {
               
                if (content.hasClass("collapsed")) {
                    content.removeClass("collapsed")
                    $(this).text("بستن")
                }
                else {
                    content.addClass("collapsed")
                    $(this).text('نمایش بیشتر')
                }
            });
        };
        footer();
    }
}



 function compare_page(){
     $(window).scroll(function (){
        var container=$('.js-compare_container');
        var container_top=container.offset().top;
        if($(this).scrollTop() >= container_top - 100){
            container.addClass('is-sticky');
        }
        else{
            container.removeClass('is-sticky')
        }
     });

     $('.js-compare_add').click(function(){
        var add_compare=$('[data-remodal-id=add-compare-product]').remodal();
        add_compare.open();
    });

 }



 function mainswiper(){
	  
    new Swiper('.c-swiper_container', {
               
           breakpointsInverse: true,
           speed: 700,
           slidesPerView: 2,
           spaceBetween: 10,
           slidesPerGroup:1,
           breakpoints: {
               1680: {
                   slidesPerView: 5,
                   spaceBetween: 10,
                   slidesPerGroup:4,
               },
               1368: {
                   slidesPerView: 5,
                   spaceBetween: 10,
                   slidesPerGroup:4,
               },
               1008: {
                   slidesPerView: 4,
                   spaceBetween: 10,
                   slidesPerGroup:3,
                   
               },
           },
                       
           
           navigation: {
               nextEl: '.js-swiper_btn-next',
               prevEl: '.js-swiper_btn-prev',
           },
   
   
   });
     }
    


     $(function(){
        $(".js-mobile-input_search").on("focus",function(){
            $(this).parent().parent().addClass("is-active")
        })
    })


    $(function(){
        var main_menu= $(".js-mobile-main_menu");
        var menu_button=$(".js-mobile-header_categories")
        var overlay=$(".js-mobile-menu_overlay");

        menu_button.on("click",function(){
            main_menu.addClass("is-active");
            overlay.addClass("is-active")
            $(".js-mobile-header_logo").fadeOut();
            $("html").css("overflow","hidden")
        })

        overlay.on("click",function(){
            main_menu.removeClass("is-active");
            overlay.removeClass("is-active")
            $(".js-mobile-header_logo").fadeIn()
            $("html").css("overflow","auto")

        })
    })
    
    $(".js-mobile_menu-item").on("click",function(){
        var that=$(this);
        if(that.hasClass("is-active"))
        {
            that.removeClass("is-active")
        }
        else{
            that.parent().parent().find(".is-active").removeClass("is-active")
            that.addClass("is-active")
        }
    })


    $(function(){
        
      
        


        
            
        var header=$(".js-header");
        var header_height=header.height(),
            input= $(".js-mobile-input_search");
        var position=$(window).scrollTop();

        $(window).scroll(function(){
            if($(document).width() < 768){
            var current_position=$(window).scrollTop();
            if(input.is(":focus")) return;

            if(current_position < position){
                header.css("transform","translateY(0)")
            }
            else{
                header.css("transform","translateY("+(current_position < header_height ? -current_position + "px" : -header_height + "px")+")")
            }

            position=current_position;
        }
        else{
            header.css("transform","translateY(0)")
        }
        })
    
    })