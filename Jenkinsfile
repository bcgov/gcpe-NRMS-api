// Edit your app's name below
def APP_NAME = 'nrms-api'

// Edit your environment TAG names below
def TAG_NAMES = [
  'dev',
  'test',
  'prod'
]
def TAG_NAMES_BACKUP = [
  'dev-previous',
  'test-previous',
  'prod-previous'
]

// You shouldn't have to edit these if you're following the conventions
def BUILD_CONFIG = APP_NAME
def IMAGESTREAM_NAME = APP_NAME

// Checks whether we are running this pipeline for the first time by looking at what tags are available on the application's ImageStream
def tagExists(is_name, tag) {
  // Get all tags already applied to this ImageStream (as a single string); e.g., 'dev test dev-previous my-other-tag'
  def output = sh (
    script: """oc get is ${is_name} -o template --template='{{range .status.tags}}{{" "}}{{.tag}}{{end}}'""",
    returnStdout: true).trim()
  def ALL_TAGS = output.split(" ")
  for (item in ALL_TAGS) {
    if (item == tag) {
      return true
    }
  }
  return false
}

node {
  /* Build stage
      - applying OpenShift build configs
      - creating OpenShift imagestreams, annotations and builds
      - build time optimizations (e.g. image reuse, build scheduling/readiness)
  */
  stage('Build ' + BUILD_CONFIG) {
    echo ">>>>>> Building: ${BUILD_CONFIG}"
    openshiftBuild bldCfg: BUILD_CONFIG, showBuildLogs: 'true', waitTime: '900000'

    // Don't tag with BUILD_ID so the pruner can do it's job; it won't delete tagged images.
    // Tag the images for deployment based on the image's hash
    IMAGE_HASH = sh (
      script: """oc get istag ${IMAGESTREAM_NAME}:latest | grep sha256: | awk -F "sha256:" '{print \$3}'""",
      returnStdout: true).trim()

    echo ">>>>>> IMAGE_HASH: ${IMAGE_HASH}"
    echo ">>>>>> Build Complete"
  }

  /* Deploy stage (DEV)
      -
      -
  */
  stage('Deploy to ' + TAG_NAMES[0]) {
    def ENVIRONMENT = TAG_NAMES[0]
    def BACKUP_TAG = TAG_NAMES_BACKUP[0]
    echo ">>>>>> Deploying to ${ENVIRONMENT}..."

    // Keep a copy of last good known configuration (just in case)
    // But skip this on the first run...
    if (tagExists(IMAGESTREAM_NAME, ENVIRONMENT)) {
      openshiftTag destStream: IMAGESTREAM_NAME, destTag: BACKUP_TAG, srcStream: IMAGESTREAM_NAME, srcTag: ENVIRONMENT, waitTime: '900000'
    }

    // Tag the new build as "dev"
    openshiftTag destStream: IMAGESTREAM_NAME, destTag: ENVIRONMENT, srcStream: IMAGESTREAM_NAME, srcTag: "${IMAGE_HASH}", waitTime: '900000'
    echo ">>>>>> Deployment Complete"
  }

  /* Deploy stage (TEST)
      -
      -
  */
  stage('Deploy to ' + TAG_NAMES[1]) {
    def ENVIRONMENT = TAG_NAMES[1]
    def BACKUP_TAG = TAG_NAMES_BACKUP[1]
    timeout(time: 4, unit: 'HOURS') {
      input message: "Promote this image to ${ENVIRONMENT}?"
    }
    echo ">>>>>> Deploying to ${ENVIRONMENT}..."

    // Keep a copy of last good known configuration (just in case)
    // But skip this on the first run...
    if (tagExists(IMAGESTREAM_NAME, ENVIRONMENT)) {
      openshiftTag destStream: IMAGESTREAM_NAME, destTag: BACKUP_TAG, srcStream: IMAGESTREAM_NAME, srcTag: ENVIRONMENT, waitTime: '900000'
    }

    // Tag the new build as "test"
    openshiftTag destStream: IMAGESTREAM_NAME, destTag: ENVIRONMENT, srcStream: IMAGESTREAM_NAME, srcTag: "${IMAGE_HASH}", waitTime: '900000'
    echo ">>>>>> Deployment Complete"
  }

  /* Deploy stage (PROD)
      -
      -
  */
  stage('Deploy to ' + TAG_NAMES[2]) {
    def ENVIRONMENT = TAG_NAMES[2]
    def BACKUP_TAG = TAG_NAMES_BACKUP[2]
    timeout(time: 4, unit: 'HOURS') {
      input message: "Promote this image to ${ENVIRONMENT}?"
    }
    echo ">>>>>> Deploying to ${ENVIRONMENT}..."

    // Keep a copy of last good known configuration (just in case)
    // But skip this on the first run...
    if (tagExists(IMAGESTREAM_NAME, ENVIRONMENT)) {
      openshiftTag destStream: IMAGESTREAM_NAME, destTag: BACKUP_TAG, srcStream: IMAGESTREAM_NAME, srcTag: ENVIRONMENT, waitTime: '900000'
    }

    // Tag the new build as "test"
    openshiftTag destStream: IMAGESTREAM_NAME, destTag: ENVIRONMENT, srcStream: IMAGESTREAM_NAME, srcTag: "${IMAGE_HASH}", waitTime: '900000'
    echo ">>>>>> Deployment Complete"
  }
}
