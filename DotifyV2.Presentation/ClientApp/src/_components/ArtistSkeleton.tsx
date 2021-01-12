import { makeStyles, Typography } from '@material-ui/core'
import { Skeleton } from '@material-ui/lab'
import React from 'react'
import MediaCoverSkeleton from './MediaCoverSkeleton'

const useStyles = makeStyles({
  name: {
    display: 'flex',
    justifyContent: 'center',
  }
})

export default ({ index }: { index: number }) => {
  const widths = [110, 60, 120]
  const classes = useStyles()

  return (
    <div>
      <MediaCoverSkeleton circular />
      <Typography variant="h6" component="h3" className={classes.name}>
        <Skeleton width={widths[index % widths.length]} animation="wave" />
      </Typography>
    </div>
  )
}
