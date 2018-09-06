# bash script to be sourced to set environment variables for OpenShift scripts
export PROJECT_NAMESPACE="nrms-api"
export PROJECT_OS_DIR=${PROJECT_OS_DIR:-../../openshift}

# The templates that should not have their GIT references(uri and ref) over-ridden
# Templates NOT in this list will have they GIT references over-ridden
# with the values of GIT_URI and GIT_REF
export skip_git_overrides=""
export GIT_URI="https://github.com/bcgov/gcpe-NRMS-api.git"
export GIT_REF="develop"

# The project components
# - defaults to the support the Simple Project Structure
export components=${components:-"Gcpe.Hub.NRMS"}

# The builds to be triggered after buildconfigs created (not auto-triggered)
export builds=${builds:-""}

# The images to be tagged after build
export images=${images:-"nrms-api"}

# The routes for the project
export routes=${routes:-""}