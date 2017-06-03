function OnPageLoad(ServerRootUrl) {
  $(document).ready(function () {
    GetFhirRest(ServerRootUrl, 'json');
    GetFhirRest(ServerRootUrl, 'xml');
  });
}

function GetFhirRest(ServerRootUrl, DataType) {
  var XmlAcceptValue = 'application/fhir+xml';
  var JsonAcceptValue = 'application/fhir+json';
  var AcceptValue = 'application/fhir+json';

  if (DataType == "xml") {
    AcceptValue = XmlAcceptValue;
  }
  else
  {
    AcceptValue = JsonAcceptValue;
  }

  $.ajax({
    url: ServerRootUrl + '/Patient/IHIStatusExample',
    headers: { 'Accept': AcceptValue },
    type: "GET",
    dataType: DataType,
    cache: false,
    error: function () {
      if (DataType = 'xml') {
        $("#fhirjson").text('Error loading FHIR ' + DataType + ' document');
      }
      else if (DataType = 'xml') {
        $("#fhirxml").text('Error loading FHIR ' + DataType + ' document');
      }
    },
    success: SwitchContent
  }); 
}


function SwitchContent(xml, status, jqxhr) {
  var ct = jqxhr.getResponseHeader("content-type") || "";
  if (ct.indexOf('application/fhir+json') > -1) {
    var d = jQuery.parseJSON(jqxhr.responseText);
    $("#fhirjson").text(JSON.stringify(d, null, '  '));
  }
  if (ct.indexOf('application/fhir+xml') > -1) {
    $("#fhirxml").text(formatXml(jqxhr.responseText));
  }   
  HighLightBlock();
}


function HighLightBlock() {

  $('pre code').each(function (i, block) {
      hljs.highlightBlock(block);
  });  
}

function formatXml(xml) {
  var formatted = '';
  var reg = /(>)(<)(\/*)/g;
  xml = xml.replace(reg, '$1\r\n$2$3');
  var pad = 0;
  jQuery.each(xml.split('\r\n'), function (index, node) {
    var indent = 0;
    if (node.match(/.+<\/\w[^>]*>$/)) {
      indent = 0;
    } else if (node.match(/^<\/\w/)) {
      if (pad != 0) {
        pad -= 1;
      }
    } else if (node.match(/^<\w[^>]*[^\/]>.*$/)) {
      indent = 1;
    } else {
      indent = 0;
    }

    var padding = '';
    for (var i = 0; i < pad; i++) {
      padding += '  ';
    }

    formatted += padding + node + '\r\n';
    pad += indent;
  });

  return formatted;
}
