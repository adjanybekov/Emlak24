"use strict";
/***************************************************************
 * Panel useful for development, where you can
 * enable or disable various theme features.
 *
 * Usually, this should be DISABLED on live website.
 ==============================================================*/
module.exports = function () {
  var _ = require('lodash');
  var panels = ['pages', 'boxed', 'patterns', 'theme_colors', 'compact', 'sidebar', 'listing_grid', 'dropdown_effects', 'slider_effects'];
  var options = {
    pages: [
      {url: 'agent_profile.html', name: 'Agent profile'},
      {url: 'agent_profile_blog_details.html', name: 'Agent profile blog details'},
      {url: 'agent_profile_blog_grid.html', name: 'Agent profile blog grid'},
      {url: 'agent_profile_blog_list.html', name: 'Agent profile blog list'},
      {url: 'agent_profile_listing_grid.html', name: 'Agent profile properties grid'},
      {url: 'agent_profile_listing_list.html', name: 'Agent profile properties list'},
      {url: 'agent_profile_listing_table.html', name: 'Agent profile properties table'},
      {url: 'agent_profile_testimonials.html', name: 'Agent profile testimonials'},
      {url: 'agents_listing_grid.html', name: 'Agent listing grid'},
      {url: 'agents_listing_list.html', name: 'Agent listing list'},
      {url: 'blog.html', name: 'Blog'},
      {url: 'blog_details.html', name: 'Blog details'},
      {url: 'blog_empty.html', name: 'Blog empty'},
      {url: 'bootstrap.html', name: 'Bootstrap'},
      {url: 'contacts.html', name: 'Contacts'},
      {url: 'dashboard.html', name: 'Dashboard'},
      {url: 'dashboard_activity.html', name: 'Dashboard activity'},
      {url: 'dashboard_blog.html', name: 'Dashboard blog'},
      {url: 'dashboard_blog_new.html', name: 'Dashboard blog new'},
      {url: 'dashboard_favorites_agents.html', name: 'Dashboard favorites agents'},
      {url: 'dashboard_favorites_listings.html', name: 'Dashboard favorites listings'},
      {url: 'dashboard_favorites_search.html', name: 'Dashboard favorites search'},
      {url: 'dashboard_financials.html', name: 'Dashboard financials'},
      {url: 'dashboard_news.html', name: 'Dashboard news'},
      {url: 'dashboard_payment.html', name: 'Dashboard payment'},
      {url: 'dashboard_profile.html', name: 'Dashboard profile'},
      {url: 'dashboard_property.html', name: 'Dashboard property'},
      {url: 'dashboard_property_new.html', name: 'Dashboard property new'},
      {url: 'dashboard_statistics.html', name: 'Dashboard statistics'},
      {url: 'faq.html', name: 'Faq'},
      {url: 'feature_boxed.html', name: 'Feature boxed'},
      {url: 'feature_grid_large.html', name: 'Feature grid large'},
      {url: 'feature_grid_small.html', name: 'Feature grid small'},
      {url: 'feature_left_sidebar.html', name: 'Feature left sidebar'},
      {url: 'feature_loaders.html', name: 'Feature loaders'},
      {url: 'feature_map_leaflet.html', name: 'Feature map leaflet'},
      {url: 'feature_typography.html', name: 'Feature typography'},
      {url: 'feature_ui.html', name: 'Feature ui'},
      {url: 'feature_vmap_fullscreen.html', name: 'Feature map fullscreen'},
      {url: 'gallery.html', name: 'Gallery'},
      {url: 'index.html', name: 'Index'},
      {url: 'index_hmap_light.html', name: 'Index map horizontal light'},
      {url: 'index_not_available.html', name: 'Index not available'},
      {url: 'index_projects.html', name: 'Index projects'},
      {url: 'index_slider.html', name: 'Index slider'},
      {url: 'index_slider_auth.html', name: 'Index slider auth'},
      {url: 'index_slider_search.html', name: 'Index slider search'},
      {url: 'index_vmap_dark.html', name: 'Index map dark'},
      {url: 'index_vmap_light.html', name: 'Index map vertical light'},
      {url: 'my_listings.html', name: 'My listings'},
      {url: 'my_listings_add_edit.html', name: 'My listings add'},
      {url: 'my_profile.html', name: 'My profile'},
      {url: 'page.html', name: 'Page'},
      {url: 'pricing.html', name: 'Pricing'},
      {url: 'properties_listing_empty.html', name: 'Properties listing empty'},
      {url: 'properties_listing_grid.html', name: 'Properties listing grid'},
      {url: 'properties_listing_list.html', name: 'Properties listing list'},
      {url: 'properties_listing_table.html', name: 'Properties listing table'},
      {url: 'property_details.html', name: 'Property details'},
      {url: 'property_details_agent.html', name: 'Property details agent'},
      {url: 'property_details_projected.html', name: 'Property details projects'},
      {url: 'reviews.html', name: 'Reviews'},
      {url: 'user_login.html', name: 'User login'},
      {url: 'user_register.html', name: 'User register'},
      {url: 'user_restore_pass.html', name: 'User restore pass'},
      {url: 'email.html', name: 'Email'},
      {url: 'error_403.html', name: 'Error 403'},
      {url: 'error_404.html', name: 'Error 404'},
      {url: 'error_500.html', name: 'Error 500'}
    ],
    boxed: false,
    bg_patterns: ['brickwall', 'debut_light', 'diagonal_lines_01', 'diagonal-noise', 'dust_2X', 'groovepaper', 'little_pluses', 'p4', 'p5',
      'retina_dust', 'ricepaper2', 'shl', 'squairy_light', 'stardust_2X', 'subtle_dots', 'subtle_dots_2X', 'white_brick_wall', 'worn_dots'],
    theme_colors: ['default', 'blue-orange_red', 'blue_green', 'brown-dark_red', 'brown-dark_yellow', 'brown_red', 'dark_blue-dark_yellow',
      'dark_blue-light_green', 'dark_blue-yellow', 'dark_violet-green', 'dark_violet-yellow', 'gray-red', 'green-red', 'green_blue-red',
      'light_blue-beige', 'light_blue-cyan', 'light_cyan-red', 'light_green-dark_blue', 'light_green-violet', 'pink_yellow'],
    header_fixed: true,
    header_colors: [['header_color_gray', 'Condensed gray'], ['header_color_white', 'Condensed white'], ['header_color_brand', 'Brand colors']],
    dropdown_effects: ['default', 'bounceInDown', 'bounceInLeft', 'bounceInRight', 'bounceInUp', 'fadeIn', 'fadeInDown', 'fadeInDownBig', 'fadeInLeft', 'fadeInLeftBig', 'fadeInRight', 'fadeInRightBig', 'fadeInUp', 'fadeInUpBig', 'zoomIn', 'zoomInDown', 'zoomInLeft', 'zoomInRight', 'zoomInUp', 'slideInDown', 'slideInLeft', 'slideInRight', 'slideInUp'],
    slider_effects: ['default', 'bounce', 'pulse', 'rubberBand', 'shake', 'swing', 'tada', 'wobble', 'bounceIn', 'bounceInDown', 'bounceInLeft', 'bounceInRight', 'bounceInUp', 'fadeIn', 'fadeInDown', 'fadeInDownBig', 'fadeInLeft', 'fadeInLeftBig', 'fadeInRight', 'fadeInRightBig', 'fadeInUp', 'fadeInUpBig', 'flipInX', 'flipInY', 'zoomIn', 'zoomInDown', 'zoomInLeft', 'zoomInRight', 'zoomInUp', 'slideInDown', 'slideInLeft', 'slideInRight', 'slideInUp'],
    hover_effects: ['default', 'apollo', 'honey', 'layla', 'lexi', 'lily', 'oscar', 'sarah', 'zoe'],
    sidebar: ['left', 'right', 'hide'],
    listing_grid: ['small', 'medium', 'big']
  };

  var UIpanel = (function () {
    var widget = {},
      $body = $('body'),
      $uiPanel,
      $uiPanelToogle,
      $linkStyles = document.querySelectorAll('link');

    widget.ui = {
      select: function (data, type, selected) {
        var _this = this;
        _this.getWrapper = function (type, options) {
          return '<select class="form-control js-uipanel-control-' + type + '"><option value="">Choose option</option>' + options + '</select>';
        };
        _this.getOptions = function (data) {
          return data.map(function (item) {
            return '<option value="' + item.value + '" ' + (selected === item.value ? 'selected' : '') + '>' + item.title + '</option>';
          });
        };

        return _this.getWrapper(type, _this.getOptions(data));
      },
      radio: function (value, title, type) {
        return '<div class="checkbox">' +
          '<input id="option_' + type + '_' + title + '" type="radio" name="' + type + '" class="in-radio js-uipanel-control-' + type + '" value="' + value + '">' +
          '<label for="option_' + type + '_' + title + '" class="in-label">' + title + '</label>' +
          '</div>';

      },
      formGroup: function (label, control) {
        return '<div class="form-group">' +
          '<label for="" class="control-label">' + label + '</label>' +
          control +
          '</div>';
      }
    };

    widget.panels = {
      pages: {
        onChange: function (e) {
          window.location.href = window.location.href.replace(/([a-z0-9_&]*\.html#?.*)$/i, e.currentTarget.value);
        },
        add: function () {
          var data = options.pages.map(function (page) {
            return {
              value: page.url,
              title: page.name
            }
          });

          var url = window.location.pathname;
          var filename = url.substring(url.lastIndexOf('/') + 1);
          var control = widget.ui.select(data, 'pages', filename);
          var formGroup = widget.ui.formGroup('Pages', control);
          $uiPanel.append(formGroup);
          widget.listeners.control('pages');
        }
      },
      boxed: {
        onChange: function (e) {
          if (e.currentTarget.value == 'true') {
            $body.addClass('boxed');
          } else {
            $body.removeClass('boxed');
          }
        },
        add: function () {
          var controls = widget.ui.radio(false, 'No', 'boxed');
          controls += widget.ui.radio(true, 'Yes', 'boxed');
          var formGroup = widget.ui.formGroup('Boxed', controls);
          $uiPanel.append(formGroup);
          widget.listeners.control('boxed');
        }
      },
      patterns: {
        onChange: function (e) {
          $body[0].className = $body[0].className.replace(/bg-[a-zX0-9_\-&]*/, '');
          $body.addClass('bg-' + e.currentTarget.value);
        },
        add: function () {
          var data = options.bg_patterns.map(function (pattern) {
            return {
              value: pattern,
              title: pattern
            }
          });

          var control = widget.ui.select(data, 'patterns');
          var formGroup = widget.ui.formGroup('Patterns', control);
          $uiPanel.append(formGroup);
          widget.listeners.control('patterns');
        }
      },
      theme_colors: {
        onChange: function (e) {
          var themeId = e.currentTarget.value;
          if (!themeId) return;
          var config = require('../module/config');
          [].forEach.call($linkStyles, function (link) {
            if (/\/css\/theme\-/.test(link.href)) {
              var xhr = new XMLHttpRequest();
              xhr.open('GET', 'assets/css/theme-' + themeId + '.css');
              xhr.send('');
              xhr.addEventListener("load", function(e) {
                console.log('loaded');
                link.href = 'assets/css/theme-' + themeId + '.css';
                config.colorTheme = themeId;
              }, false);
            }
          });
        },
        add: function () {
          var data = options.theme_colors.map(function (pattern) {
            return {
              value: pattern,
              title: pattern
            }
          });

          var control = widget.ui.select(data, 'theme_colors');
          var formGroup = widget.ui.formGroup('Theme colors', control);
          $uiPanel.append(formGroup);
          widget.listeners.control('theme_colors');
        }
      },
      dropdown_effects: {
        onChange: function (e) {
          $body[0].className = $body[0].className.replace(/menu-[a-zA-Z]*/, '');
          $body.addClass('menu-' + e.currentTarget.value);
        },
        add: function () {
          var data = options.dropdown_effects.map(function (effect) {
            return {
              value: effect,
              title: effect
            }
          });

          var control = widget.ui.select(data, 'dropdown_effects');
          var formGroup = widget.ui.formGroup('Menu effects', control);
          $uiPanel.append(formGroup);
          widget.listeners.control('dropdown_effects');
        }
      },
      slider_effects: {
        onChange: function (e) {
          $body[0].className = $body[0].className.replace(/slider\-\-[a-zA-Z]*/, '');
          $body.addClass('slider--' + e.currentTarget.value);
        },
        add: function () {
          var data = options.slider_effects.map(function (effect) {
            return {
              value: effect,
              title: effect
            }
          });

          var control = widget.ui.select(data, 'slider_effects');
          var formGroup = widget.ui.formGroup('Slider effects', control);
          $uiPanel.append(formGroup);
          widget.listeners.control('slider_effects');
        }
      },
      hover_effects: {
        onChange: function (e) {
          $body[0].className = $body[0].className.replace(/hover-[a-zA-Z]*/, '');
          $body.addClass('hover-' + e.currentTarget.value);
        },
        add: function () {
          var data = options.hover_effects.map(function (effect) {
            return {
              value: effect,
              title: effect
            }
          });

          var control = widget.ui.select(data, 'hover_effects');
          var formGroup = widget.ui.formGroup('Hover effects', control);
          $uiPanel.append(formGroup);
          widget.listeners.control('hover_effects');
        }
      },
      compact: {
        onChange: function (e) {
          if (e.currentTarget.value == 'true') {
            $body.addClass('compact');
          } else {
            $body.removeClass('compact');
          }
        },
        add: function () {
          var controls = widget.ui.radio(false, 'No', 'compact');
          controls += widget.ui.radio(true, 'Yes', 'compact');
          var formGroup = widget.ui.formGroup('Header compact', controls);
          $uiPanel.append(formGroup);
          widget.listeners.control('compact');

        }
      },
      header_colors: {
        onChange: function (e) {
          $body[0].className = $body[0].className.replace(/header_color_[a-zX0-9_\-&]*/, '');
          $body.addClass(e.currentTarget.value);
        },
        add: function () {
          var data = options.header_colors.map(function (style) {
            return {
              value: style[0],
              title: style[1]
            }
          });

          var control = widget.ui.select(data, 'header_colors');
          var formGroup = widget.ui.formGroup('Header style', control);
          $uiPanel.append(formGroup);
          widget.listeners.control('header_colors');
        }
      },
      sidebar: {
        onChange: function (e) {
          $body[0].className = $body[0].className.replace(/sidebar-[a-zX0-9_\-&]*/, '');
          $body.addClass('sidebar-' + e.currentTarget.value);
        },
        add: function () {
          var controls = options.sidebar.map(function (type) {
            return widget.ui.radio(type, type, 'sidebar');
          });

          var formGroup = widget.ui.formGroup('Sidebar', controls);
          $uiPanel.append(formGroup);
          widget.listeners.control('sidebar');
        }
      },
      listing_grid: {
        onChange: function (e) {
          $body[0].className = $body[0].className.replace(/listing-grid-[a-zX0-9_\-&]*/, '');
          $body.addClass('listing-grid-' + e.currentTarget.value);
        },
        add: function () {
          var controls = options.listing_grid.map(function (type) {
            return widget.ui.radio(type, type, 'listing_grid');
          });

          var formGroup = widget.ui.formGroup('Listing grid', controls);
          $uiPanel.append(formGroup);
          widget.listeners.control('listing_grid');
        }
      }
    };

    widget.addPanels = function (_panels) {
      _panels.forEach(function (panel) {
        widget.panels[panel].add();
      });
    };

    widget.listeners = {
      panel: function () {
        $uiPanel = $('.js-ui-panel');
        $uiPanelToogle = $('.js-ui-panel-toggle');
        $uiPanelToogle.on('click', function () {
          if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            $uiPanel.removeClass('opened');
          } else {
            $(this).addClass('active');
            $uiPanel.addClass('opened');
          }
        });

        var $uiPanelButtonScroll = $('.js-ui-panel-scroll');

        $uiPanelButtonScroll.on('click', function () {
          var delta = $(this).data('dir') == 'up' ? -500 : 500;
          var offsetTop = $(window).scrollTop();
          $('html, body').animate({scrollTop: offsetTop + delta}, 100);
        });

        var $uiPanelButtonNext = $('.js-ui-panel-next');

        $uiPanelButtonNext.on('click', function () {
          var $uiControlPages = $('.js-uipanel-control-pages');
          var current = $uiControlPages.find('option:selected').index();
          var $uiControlPagesNext = $uiControlPages.find('option')[current+1];
          var url = $($uiControlPagesNext).attr('value');
          if (url) window.location.href = window.location.href.replace(/([a-z0-9_&]*\.html#?.*)$/i, url);
        });
      },
      control: function (type) {
        $('.js-uipanel-control-' + type).on('change', function (e) {
          widget.panels[type].onChange(e);
        });
      }
    };


    widget.init = function (_panels) {

      $('<link>')
        .appendTo('head')
        .attr({type: 'text/css', rel: 'stylesheet'})
        .attr('href', 'assets/css/ui-panel.css');

      var htmlBlock = '<div class="ui-panel js-ui-panel">' +
        '<button class="ui-panel__toggle js-ui-panel-toggle"></button>' +
        '<button type="button" class="ui-panel__btn ui-panel__btn--up js-ui-panel-scroll" data-dir="up"></button>' +
        '<button type="button" class="ui-panel__btn ui-panel__btn--down js-ui-panel-scroll" data-dir="down"></button>' +
        '<button type="button" class="ui-panel__btn ui-panel__btn--next js-ui-panel-next"></button>' +
        '</div>';
      $body.append(htmlBlock);

      widget.listeners.panel();
      widget.addPanels(_panels);
    };

    return widget;
  })();
  setTimeout(function(){
    UIpanel.init(panels);
    return UIpanel;
  });
};
