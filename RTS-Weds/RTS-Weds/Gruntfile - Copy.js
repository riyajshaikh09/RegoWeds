/*jslint node: true */
"use strict";


module.exports = function (grunt) {

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),

        bower: {
            install: {
                options: {
                    install: true,
                    copy: false,
                    targetDir: './libs',
                    cleanTargetDir: true
                }
            }
        },
     
        uglify: {
            dist: {
                files: {
                    'dist/app.min.js': ['tmp/app.js'],
                    'dist/base.min.js': ['tmp/base.js'],
                   
                },
                options: {
                    mangle: false
                }
            }
        },

        html2js: {
            dist: {
                src: ['app/template/*.html'],
                dest: 'tmp/templates.js',
               
            }
        },

        clean: {
            temp: {
                src: ['tmp']
            }
        },

            concat: {
                options: {
                    separator: ';'
                },
                dist: {
                    src: ['app/*.js', 'app/**/*.js', 'tmp/*.js'],
                    dest: 'tmp/app.js'
                },
                base: {
                    src:
                        [
                            'Scripts/angular.min.js',
                            'Scripts/angular-route.min.js',
                            'Scripts/angular-material.min.js',
                            'Scripts/angular-animate.min.js',
                            'Scripts/angular-aria.min.js'
                        ],
                    dest: 'tmp/base.js'
                },
                mainCss: {
                    src:
                        [
                            'Content/angular-material.css',
                            'Content/bootstrap.css',
                            'Content/site.css',
                        
                        ],
                    dest: 'dist/maincss.css'
                }
            },

        jshint: {
            all: ['Gruntfile.js', 'app/*.js', 'app/**/*.js']
        },

        connect: {
            server: {
                options: {                    hostname: 'localhost',
                    port: 8080
                }
            }
        },

        watch: {
            dev: {
                files: ['Gruntfile.js', 'app/*.js', '*.html'],
                tasks: ['html2js:dist', 'concat:mainCss', 'concat:base', 'concat:dist', 'uglify:dist', 'clean:temp'],
                options: {
                    atBegin: true
                }
            },
            min: {
                files: ['Gruntfile.js', 'app/*.js', '*.html'],
                tasks: ['jshint', 'karma:unit', 'html2js:dist', 'concat:dist', 'clean:temp', 'uglify:dist'],
                options: {
                    atBegin: true
                }
            }
        },

        compress: {
            dist: {
                options: {
                    archive: 'build/<%= pkg.name %>-<%= pkg.version %>.zip'
                },
                files: [{
                    src: ['index.html'],
                    dest: '/'
                }, {
                    src: ['dist/**'],
                    dest: '/'
                }, {
                    src: ['assets/**'],
                    dest: 'assets/'
                }, {
                    src: ['libs/**'],
                    dest: 'libs/'
                }]
            }
        },

       
    });
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-contrib-compress');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-html2js');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-bower-task');
    

    grunt.registerTask('build', ['bower', 'html2js:dist', 'concat:mainCss', 'concat:base', 'concat:dist', 'uglify:dist', 'clean:temp']);
    grunt.registerTask('dev', ['bower', 'connect:server', 'watch:dev']);
    grunt.registerTask('minified', ['bower', 'connect:server', 'watch:min']);
    grunt.registerTask('package', ['bower', 'html2js:dist', 'concat:mainCss', 'concat:base', 'concat:dist', 'uglify:dist', 'clean:temp', 'compress:dist']);
};