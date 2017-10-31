/// <reference path="../ckfinder/ckfinder.html" />
/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControl = true;
    config.language = 'vi';
    config.filebrowerBrowseUrl = '/Assets/Public/Plugins/ckfinder/ckfinder.html';
    config.filebrowerImageBrowseUrl = '/Assets/Public/Plugins/ckfinder/ckfinder.html?Type=Images';
    config.filebrowerFlashBrowseUrl = '/Assets/Public/Plugins/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowerUploadUrl = '/Assets/Public/Plugins/ckfinder/core/connector/aspx/connect.aspx?command=QuickUpload&Type=File';
    config.filebrowerImageUploadUrl = '/Upload/';
    config.filebrowerFlashUploadUrl = '/Assets/Public/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&Type=Flash'

    CKFinder.setupCKEditor(null, '/Assets/Public/Plugins/ckfinder/');
};
