(function() {

    /*

        Options:

        - daysNode
        - hoursNode
        - minutesNode
        - secondsNode
        - endDatetime
        - timeLeft

        API:

        - start
        - pause
        - stop
        - resume
        - restart

        Events:

        - start
        - pause
        - stop
        - resume
        - restart

    */

    var CountDown = Base.extend({
        initialize: function(options) {
            CountDown.superclass.initialize.apply(this, arguments);
            this.options = options || {};
        },

        _timeleft: function() {
            if(this.get('timeLeft') !== null) {
                return this.get('timeLeft');
            }

            if(this.options.timeLeft) {
                return this.options.timeLeft;
            }

            return (this.options.endDatetime.getTime() - new Date().getTime()) / 1000;
        },

        _run: function() {
            var time_left = this._timeleft();
            var d, h, m;
            var days = this.options.daysNode;
            var hours = this.options.hoursNode;
            var minutes = this.options.minutesNode;
            var seconds = this.options.secondsNode;
            
            // any callback you want to put when the countdown finishes
            if(time_left <= 0) {
                this.end();
                days.html(this._fixNumber(0));
                hours.html(this._fixNumber(0));
                minutes.html(this._fixNumber(0));
                seconds.html(this._fixNumber(0));
                countDownFinished();
                return;
            }
            
            d = Math.floor(time_left / 86400);
            time_left -= d * 86400;
            
            h = Math.floor(time_left / 3600);
            time_left -= h * 3600;
            
            m = Math.floor(time_left / 60);
            time_left -= m * 60;
            
            days.html(this._fixNumber(d));
            hours.html(this._fixNumber(h));
            minutes.html(this._fixNumber(m));
            seconds.html(this._fixNumber(Math.floor(time_left)));
            this.set('timeLeft', this._timeleft() - 1);
        },

        _start: function() {
            var run = (function(context) {
                return function() {
                    context._run.apply(context);
                }
            })(this);

            var time_loop = setInterval(run, 1000);
            this.set('time_loop', time_loop);
        },

        _pause: function() {
            clearInterval(this.get('time_loop'));
        },

        _resume: function() {
            this._start();
        },

        _stop: function() {
            clearInterval(this.get('time_loop'));
            this.set('timeLeft', null);
        },

        _fixNumber: function(number) {
            number = number.toString();

            if(number.length === 1) {
                return '0' + number;
            }

            return number;
        },

        start: function() {
            this._start();
            this.trigger('start');
        },

        pause: function() {
            this._pause();
            this.trigger('pause');
        },

        stop: function() {
            this._stop();
            this.trigger('stop');
        },

        resume: function() {
            this._resume();
            this.trigger('resume');
        },

        restart: function() {
            this._stop();
            this._start();
            this.trigger('restart');
        },

        end: function() {
            this._stop();
            this.trigger('end');
        }
    });

    this.CountDown = CountDown;

}).call(this);
