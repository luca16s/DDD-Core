#!/usr/bin/env bash
curl -s https://codecov.io/bash > codecov
chmod +x codecov
./codecov -f "./CodeCoverageResults/coverage.opencover.xml" -t CODECOV_TOKEN