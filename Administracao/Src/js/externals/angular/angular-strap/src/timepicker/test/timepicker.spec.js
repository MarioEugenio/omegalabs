'use strict';

describe('timepicker', function() {

  var $compile, $templateCache, $timepicker, dateFilter, scope, sandboxEl, today;

  beforeEach(module('ngSanitize'));
  beforeEach(module('mgcrea.ngStrap.timepicker'));

  beforeEach(inject(function (_$rootScope_, _$compile_, _$templateCache_, _$timepicker_, _dateFilter_) {
    scope = _$rootScope_.$new();
    sandboxEl = $('<div>').attr('id', 'sandbox').appendTo($('body'));
    $compile = _$compile_;
    $templateCache = _$templateCache_;
    $timepicker = _$timepicker_;
    dateFilter = _dateFilter_;
    today = new Date();
  }));

  afterEach(function() {
    scope.$destroy();
    sandboxEl.remove();
  });

  // Templates

  var templates = {
    'default': {
      scope: {selectedTime: new Date()},
      element: '<input type="text" ng-model="selectedTime" bs-timepicker>'
    },
    'value-undefined': {
      element: '<input type="text" ng-model="selectedUndefined" bs-timepicker>'
    },
    'value-past': {
      scope: {selectedTime: new Date(1970, 0, 1, 10, 30)},
      element: '<input type="text" ng-model="selectedTime" bs-timepicker>'
    },
    'markup-ngRepeat': {
      element: '<ul><li ng-repeat="i in [1, 2, 3]"><input type="text" ng-model="selectedTime" bs-timepicker></li></ul>'
    },
    'options-animation': {
      element: '<div class="btn" data-animation="animation-flipX" ng-model="timepickeredIcon" ng-options="icon.value as icon.label for icon in icons" bs-timepicker></div>'
    },
    'options-placement': {
      element: '<div class="btn" data-placement="bottom" ng-model="timepickeredIcon" ng-options="icon.value as icon.label for icon in icons" bs-timepicker></div>'
    },
    'options-placement-exotic': {
      element: '<div class="btn" data-placement="bottom-right" ng-model="timepickeredIcon" ng-options="icon.value as icon.label for icon in icons" bs-timepicker></div>'
    },
    'options-trigger': {
      element: '<div class="btn" data-trigger="hover" ng-model="timepickeredIcon" ng-options="icon.value as icon.label for icon in icons" bs-timepicker></div>'
    },
    'options-template': {
      element: '<input type="text" data-template="custom" ng-model="selectedTime" bs-timepicker>'
    },
    'options-timeFormat': {
      scope: {selectedTime: new Date(1970, 0, 1, 10, 30)},
      element: '<input type="text" ng-model="selectedTime" data-time-format="HH:mm" bs-timepicker>'
    },
    'options-minTime': {
      scope: {selectedTime: new Date(1970, 0, 1, 10, 30), minTime: '09:30 AM'},
      element: '<input type="text" ng-model="selectedTime" data-min-time="{{minTime}}" bs-timepicker>'
    },
    'options-minTime-now': {
      scope: {},
      element: '<input type="text" ng-model="selectedTime" data-min-time="now" bs-timepicker>'
    },
    'options-maxTime-now': {
      scope: {},
      element: '<input type="text" ng-model="selectedTime" data-max-time="now" bs-timepicker>'
    },
    'options-maxTime': {
      scope: {selectedTime: new Date(1970, 0, 1, 10, 30), maxTime: '10:30 PM'},
      element: '<input type="text" ng-model="selectedTime" data-max-time="{{maxTime}}" bs-timepicker>'
    },
    'options-autoclose': {
      element: '<input type="text" ng-model="selectedTime" data-autoclose="1" bs-timepicker>'
    },
    'options-useNative': {
      element: '<input type="text" ng-model="selectedTime" data-use-native="1" bs-timepicker>'
    }
  };

  function compileDirective(template, locals) {
    template = templates[template];
    angular.extend(scope, template.scope || templates['default'].scope, locals);
    var element = $(template.element).appendTo(sandboxEl);
    element = $compile(element)(scope);
    scope.$digest();
    return jQuery(element[0]);
  }

  // Tests

  describe('with default template', function() {

    it('should open on focus', function() {
      var elm = compileDirective('default');
      expect(sandboxEl.children('.dropdown-menu.timepicker').length).toBe(0);
      angular.element(elm[0]).triggerHandler('focus');
      expect(sandboxEl.children('.dropdown-menu.timepicker').length).toBe(1);
    });

    it('should close on blur', function() {
      var elm = compileDirective('default');
      expect(sandboxEl.children('.dropdown-menu.timepicker').length).toBe(0);
      angular.element(elm[0]).triggerHandler('focus');
      angular.element(elm[0]).triggerHandler('blur');
      expect(sandboxEl.children('.dropdown-menu.timepicker').length).toBe(0);
    });

    it('should correctly compile inner content', function() {
      var elm = compileDirective('default');
      angular.element(elm[0]).triggerHandler('focus');
      expect(sandboxEl.find('.dropdown-menu tbody tr').length).toBe($timepicker.defaults.length);
      expect(sandboxEl.find('.dropdown-menu tbody .btn').length).toBe($timepicker.defaults.length * 4);
    });

    it('should correctly display active time', function() {
      var elm = compileDirective('default');
      angular.element(elm[0]).triggerHandler('focus');
      expect(sandboxEl.find('.dropdown-menu tbody tr:eq(2) td:eq(0) .btn-primary').text()).toBe(dateFilter(scope.selectedTime, 'h'));
      expect(sandboxEl.find('.dropdown-menu tbody tr:eq(2) td:eq(2) .btn-primary').text()).toBe(dateFilter(scope.selectedTime, 'mm'));
      expect(sandboxEl.find('.dropdown-menu tbody tr:eq(2) td:eq(4) .btn-primary').text()).toBe(dateFilter(scope.selectedTime, 'a'));
    });

    it('should correctly support undefined values', function() {
      var elm = compileDirective('value-undefined');
      angular.element(elm[0]).triggerHandler('focus');
      expect(sandboxEl.find('.dropdown-menu tbody tr').length).toBe($timepicker.defaults.length);
      expect(sandboxEl.find('.dropdown-menu tbody .btn').length).toBe($timepicker.defaults.length * 4);
    });

    it('should support ngRepeat markup', function() {
      var elm = compileDirective('markup-ngRepeat');
      angular.element(elm.find('[bs-timepicker]:eq(0)')).triggerHandler('focus');
      expect(sandboxEl.find('.dropdown-menu tbody tr').length).toBe($timepicker.defaults.length);
      expect(sandboxEl.find('.dropdown-menu tbody .btn').length).toBe($timepicker.defaults.length * 4);
    });

    // iit('should only build the timepicker once', function() {
    //   var elm = compileDirective('value-past');
    //   angular.element(elm[0]).triggerHandler('focus');
    // });

  });

  // describe('using service', function() {

  //   it('should correctly open on next digest', function() {
  //     var myModal = $modal(templates['default'].scope.modal);
  //     scope.$digest();
  //     expect(bodyEl.children('.modal').length).toBe(1);
  //     myModal.hide();
  //     expect(bodyEl.children('.modal').length).toBe(0);
  //   });

  //   it('should correctly be destroyed', function() {
  //     var myModal = $modal(angular.extend(templates['default'].scope.modal));
  //     scope.$digest();
  //     expect(bodyEl.children('.modal').length).toBe(1);
  //     myModal.destroy();
  //     expect(bodyEl.children('.modal').length).toBe(0);
  //     expect(bodyEl.children().length).toBe(1);
  //   });

  //   it('should correctly work with ngClick', function() {
  //     var elm = compileDirective('markup-ngClick-service');
  //     var myModal = $modal(angular.extend({show: false}, templates['default'].scope.modal));
  //     scope.showModal = function() {
  //       myModal.$promise.then(myModal.show);
  //     };
  //     expect(bodyEl.children('.modal').length).toBe(0);
  //     angular.element(elm[0]).triggerHandler('click');
  //     expect(bodyEl.children('.modal').length).toBe(1);
  //   });

  // });

  describe('options', function() {

    describe('animation', function() {

      it('should default to `animation-fade` animation', function() {
        var elm = compileDirective('default');
        angular.element(elm[0]).triggerHandler('focus');
        expect(sandboxEl.children('.dropdown-menu').hasClass('animation-fade')).toBeTruthy();
      });

      it('should support custom animation', function() {
        var elm = compileDirective('options-animation');
        angular.element(elm[0]).triggerHandler('focus');
        expect(sandboxEl.children('.dropdown-menu').hasClass('animation-flipX')).toBeTruthy();
      });

    });

    describe('autoclose', function() {

      it('should close on select', function() {
        var elm = compileDirective('options-autoclose');
        expect(sandboxEl.children('.dropdown-menu.timepicker').length).toBe(0);
        angular.element(elm[0]).triggerHandler('focus');
        angular.element(sandboxEl.find('.dropdown-menu tbody .btn:first')).triggerHandler('click');
        expect(sandboxEl.children('.dropdown-menu.timepicker').length).toBe(0);
      });

    });

    describe('placement', function() {

      it('should default to `bottom-left` placement', function() {
        var elm = compileDirective('default');
        angular.element(elm[0]).triggerHandler('focus');
        expect(sandboxEl.children('.dropdown-menu').hasClass('bottom-left')).toBeTruthy();
      });

      it('should support placement', function() {
        var elm = compileDirective('options-placement');
        angular.element(elm[0]).triggerHandler('focus');
        expect(sandboxEl.children('.dropdown-menu').hasClass('bottom')).toBeTruthy();
      });

      it('should support exotic-placement', function() {
        var elm = compileDirective('options-placement-exotic');
        angular.element(elm[0]).triggerHandler('focus');
        expect(sandboxEl.children('.dropdown-menu').hasClass('bottom-right')).toBeTruthy();
      });

    });

    describe('trigger', function() {

      it('should support an alternative trigger', function() {
        var elm = compileDirective('options-trigger');
        expect(sandboxEl.children('.dropdown-menu').length).toBe(0);
        angular.element(elm[0]).triggerHandler('mouseenter');
        expect(sandboxEl.children('.dropdown-menu').length).toBe(1);
        angular.element(elm[0]).triggerHandler('mouseleave');
        expect(sandboxEl.children('.dropdown-menu').length).toBe(0);
      });

    });

    describe('template', function() {

      it('should support custom template', function() {
        $templateCache.put('custom', '<div class="dropdown"><div class="dropdown-inner">foo: {{selectedTime}}</div></div>');
        var elm = compileDirective('options-template');
        angular.element(elm[0]).triggerHandler('focus');
        expect(sandboxEl.find('.dropdown-inner').text()).toBe('foo: "' + scope.selectedTime.toISOString() + '"');
      });

      it('should support template with ngRepeat', function() {
        $templateCache.put('custom', '<div class="dropdown"><div class="dropdown-inner"><ul><li ng-repeat="i in [1, 2, 3]">{{i}}</li></ul></div></div>');
        var elm = compileDirective('options-template');
        angular.element(elm[0]).triggerHandler('focus');
        expect(sandboxEl.find('.dropdown-inner').text()).toBe('123');
        // Consecutive toggles
        angular.element(elm[0]).triggerHandler('focus');
        angular.element(elm[0]).triggerHandler('blur');
        expect(sandboxEl.find('.dropdown-inner').text()).toBe('123');
      });

      it('should support template with ngClick', function() {
        $templateCache.put('custom', '<div class="dropdown"><div class="dropdown-inner"><a class="btn" ng-click="dropdown.counter=dropdown.counter+1">click me</a></div></div>');
        var elm = compileDirective('options-template');
        scope.dropdown = {counter: 0};
        angular.element(elm[0]).triggerHandler('focus');
        expect(angular.element(sandboxEl.find('.dropdown-inner > .btn')[0]).triggerHandler('click'));
        expect(scope.dropdown.counter).toBe(1);
        // Consecutive toggles
        angular.element(elm[0]).triggerHandler('focus');
        angular.element(elm[0]).triggerHandler('blur');
        expect(angular.element(sandboxEl.find('.dropdown-inner > .btn')[0]).triggerHandler('click'));
        expect(scope.dropdown.counter).toBe(2);
      });

    });

    describe('timeFormat', function() {

      it('should support a custom timeFormat', function() {
        var elm = compileDirective('options-timeFormat');
        expect(elm.val()).toBe('10:30');
        angular.element(elm[0]).triggerHandler('focus');
        angular.element(sandboxEl.find('.dropdown-menu tbody .btn:contains(09)')).triggerHandler('click');
        expect(elm.val()).toBe('09:30');
      });

    });

    describe('minTime', function() {

      it('should support a dynamic minTime', function() {
        var elm = compileDirective('options-minTime');
        angular.element(elm[0]).triggerHandler('focus');
        expect(sandboxEl.find('.dropdown-menu tbody button:contains(8)').is(':disabled')).toBeTruthy();
        scope.minTime = '08:30 AM';
        scope.$digest();
        expect(sandboxEl.find('.dropdown-menu tbody button:contains(8)').is(':disabled')).toBeFalsy();
      });

      it('should support now as minTime', function() {
        var elm = compileDirective('options-minTime-now');
        angular.element(elm[0]).triggerHandler('focus');
        var todayHour = today.getHours();
        expect(sandboxEl.find('.dropdown-menu tbody button:contains(' + (todayHour - 1) + ')').is(':disabled')).toBeTruthy();
      });

    });

    describe('maxTime', function() {

      it('should support a dynamic maxTime', function() {
        var elm = compileDirective('options-maxTime');
        angular.element(elm[0]).triggerHandler('focus');
        // @TODO fixme
        // expect(sandboxEl.find('.dropdown-menu tbody button:contains(11)').is(':disabled')).toBeTruthy();
        // scope.maxTime = '10:30 AM';
        // scope.$digest();
        // expect(sandboxEl.find('.dropdown-menu tbody button:contains(11)').is(':disabled')).toBeTruthy();
      });

      it('should support now as maxTime', function() {
        var elm = compileDirective('options-maxTime-now');
        angular.element(elm[0]).triggerHandler('focus');
        var todayHour = today.getHours();
        // @TODO fixme
        // expect(sandboxEl.find('.dropdown-menu tbody button:contains(' + (todayHour + 1) + ')').is(':disabled')).toBeTruthy();
      });

    });

    describe('useNative', function() {

      it('should correctly compile template according to useNative', function() {
        var elm = compileDirective('options-useNative');
        angular.element(elm[0]).triggerHandler('focus');
        // @TODO ?
      });

    });

  });

});
