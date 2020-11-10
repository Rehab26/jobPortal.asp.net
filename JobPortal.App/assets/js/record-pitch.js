/*
var video, reqBtn, startBtn, stopBtn, ul, stream, recorder;
video = document.getElementById('video');
reqBtn = document.getElementById('request');
startBtn = document.getElementById('start');
stopBtn = document.getElementById('stop');
ul = document.getElementById('ul');
reqBtn.onclick = requestVideo;
startBtn.onclick = startRecording;
stopBtn.onclick = stopRecording;
startBtn.disabled = true;
ul.style.display = 'none';
stopBtn.disabled = true;

function requestVideo() {
    navigator.mediaDevices.getUserMedia({
        video: true,
        audio: true
    })
      .then(stm => {
          stream = stm;
          reqBtn.style.display = 'none';
          startBtn.removeAttribute('disabled');
          video.src = URL.createObjectURL(stream);
      }).catch(e => console.error(e));
}

function startRecording() { 
    //recorder = new MediaRecorder(stream, {
    //    mimeType: 'video/mp4'
    //});

    recorder = new MediaRecorder(stream)

    recorder.start();
    stopBtn.removeAttribute('disabled');
    startBtn.disabled = true;
}


function stopRecording() {
    recorder.ondataavailable = e => {
        ul.style.display = 'block';
        var a = document.createElement('a'),
          li = document.createElement('li');
        a.download = ['video_', (new Date() + '').slice(4, 28), '.webm'].join('');
        a.href = URL.createObjectURL(e.data);
        a.textContent = a.download;
        li.appendChild(a);
        ul.appendChild(li);
    };
    recorder.stop();
    startBtn.removeAttribute('disabled');
    stopBtn.disabled = true;
}

*/





debugger


/*
    $(function(){    
        if (hasGetUserMedia()) {
            alert("Good to go!")
        } else {
            alert('getUserMedia() is not supported in your browser');
        }
        
        navigator.getUserMedia = navigator.getUserMedia ||
                          navigator.webkitGetUserMedia ||
                          navigator.mozGetUserMedia ||
                          navigator.msGetUserMedia;

        var video = document.querySelector('video');

                
if (navigator.getUserMedia) {
    navigator.getUserMedia({ audio: true, video: true }, function (stream) {

        video.src = window.URL.createObjectURL(stream);
        video.onloadedmetadata = function (e) {
            
            alert("Onloadedmetadata fired")
        };
    }, errorCallback);

    //navigator.getUserMedia(constraints, successCallback, errorCallback);
           

} else {
    video.src = 'somevideo.webm'; // fallback.
}

})

function hasGetUserMedia() {
    return !!(navigator.getUserMedia || navigator.webkitGetUserMedia ||
              navigator.mozGetUserMedia || navigator.msGetUserMedia);
}

function sourceSelected(audioSource, videoSource) {
    var constraints = {
        audio: {
            optional: [{ sourceId: audioSource }]
        },
        video: {
            optional: [{ sourceId: videoSource }]
        }
    };
}

var errorCallback = function (e) {
    console.log('Not supported!', e);
};
*/

$(function () {
    var video = document.querySelector('video');
    var canvas = document.querySelector('canvas');
    var ctx = canvas.getContext('2d');
    var localMediaStream = null;

    video.addEventListener('click', snapshot, false);


    navigator.getUserMedia({ audio: true, video: true }, function (stream) {

        video.src = window.URL.createObjectURL(stream);
        localMediaStream = stream;
        video.onloadedmetadata = function (e) {

            alert("Onloadedmetadata fired")
        };
    }, errorCallback);


    function snapshot() {
        if (localMediaStream) {
            ctx.drawImage(video, 0, 0);
            // "image/webp" works in Chrome.
            // Other browsers will fall back to image/png.
            document.querySelector('img').src = canvas.toDataURL('image/webp');

            var outVid = document.querySelector("#vid1");
            outVid.src = canvas.toDataURL('video');
            outVid.play();
        }
    }

})





// Not showing vendor prefixes or code that works cross-browser.
/*
navigator.getUserMedia({ video: true }, function (stream) {
    video.src = window.URL.createObjectURL(stream);
    localMediaStream = stream;
}, errorCallback);
*/

var errorCallback = function (e) {
    console.log('Reeeejected!', e);
};

function submitPitch(jobId) {
    //$('#myModal').modal(options);
    //$('#myModal').modal('show');
        
    $.ajax({
        type: "POST",
        url: "/Job/SubmitPitch?jobId=" + jobId,
        //data: JSON.stringify(resume), 
        contentType: "application/json",
        processData: false,

        success: function (result) {
                
            if (result.subStatus == "1") {
                alert(result.msg)
            }
            else {
                alert(result.msg)
                //pop-up modal
                var options = { "backdrop": "static", keyboard: true };
                $('#myModal').modal(options);
                $('#myModal').modal('show');
            }
        }
        ,
        error: function () {
            alert("Dynamic content load failed.");
        }
    })
        

}

