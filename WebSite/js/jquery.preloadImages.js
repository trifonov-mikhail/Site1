(function($){
    jQuery.preloadImages = function(options)
    {
        var loadedCount = 0;
        var toLoadCount = 0;
        var defaults = 
        {
            images:[],
            oneLoaded:function(img){},
            allLoaded:function(){}
        };
        var o = $.extend(defaults, options);
        toLoadCount = o.images.length;
        for (var i = 0;i<toLoadCount; i++) {
            var img = jQuery('<img/>');
            img.load(imgLoaded);
            img.attr("src",o.images[i]);
        }
        function imgLoaded()
        {
            loadedCount++;
            o.oneLoaded($(this));
            if (loadedCount==toLoadCount){
                o.allLoaded();
            }
        }
    }
})(jQuery);